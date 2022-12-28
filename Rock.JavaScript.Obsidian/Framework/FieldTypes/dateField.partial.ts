﻿// <copyright>
// Copyright by the Spark Development Network
//
// Licensed under the Rock Community License (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.rockrms.com/license
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//
import { Component } from "vue";
import { defineAsyncComponent } from "@Obsidian/Utility/component";
import { ComparisonType } from "@Obsidian/Enums/Reporting/comparisonType";
import { dateComparisonTypes } from "@Obsidian/Core/Reporting/comparisonType";
import { ComparisonValue } from "@Obsidian/Types/Reporting/comparisonValue";
import { asBoolean } from "@Obsidian/Utility/booleanUtils";
import { toNumber } from "@Obsidian/Utility/numberUtils";
import { calculateSlidingDateRange, getRangeTypeText, getTimeUnitText, parseSlidingDateRangeString, RangeType, TimeUnit } from "@Obsidian/Utility/slidingDateRange";
import { RockDateTime } from "@Obsidian/Utility/rockDateTime";
import { FieldTypeBase } from "./fieldType";
import { getStandardFilterComponent } from "./utils";

export const enum ConfigurationValueKey {
    Format = "format",
    DisplayDiff = "displayDiff",
    DisplayCurrentOption = "displayCurrentOption",
    DatePickerControlType = "datePickerControlType",
    FutureYearCount = "futureYearCount"
}


// The edit component can be quite large, so load it only as needed.
const editComponent = defineAsyncComponent(async () => {
    return (await import("./dateFieldComponents")).EditComponent;
});

// The configuration component can be quite large, so load it only as needed.
const configurationComponent = defineAsyncComponent(async () => {
    return (await import("./dateFieldComponents")).ConfigurationComponent;
});

// Load the filter component as needed.
const filterComponent = defineAsyncComponent(async () => {
    return (await import("./dateFieldComponents")).FilterComponent;
});

/**
 * The field type handler for the Date field.
 */
export class DateFieldType extends FieldTypeBase {
    public override getTextValue(value: string, configurationValues: Record<string, string>): string {
        if (this.isCurrentDateValue(value)) {
            return this.getCurrentDateText(value);
        }
        else if (value) {
            const dateValue = RockDateTime.parseISO(value);
            const dateFormatTemplate = configurationValues[ConfigurationValueKey.Format] || "MM/dd/yyy";

            if (dateValue !== null) {
                let textValue = dateValue.toASPString(dateFormatTemplate);

                const displayDiff = asBoolean(configurationValues[ConfigurationValueKey.DisplayDiff]);

                if (displayDiff === true) {
                    textValue = `${textValue} ${dateValue.toElapsedString()}`;
                }

                return textValue;
            }
            else {
                return "";
            }
        }
        else {
            return "";
        }
    }

    public override getEditComponent(): Component {
        return editComponent;
    }

    public override getConfigurationComponent(): Component {
        return configurationComponent;
    }

    public override getSupportedComparisonTypes(): ComparisonType {
        return dateComparisonTypes;
    }

    public override getFilterComponent(): Component {
        return getStandardFilterComponent(this.getSupportedComparisonTypes(), filterComponent, {
            updateComparisonTypeNames: (options) => {
                options.filter(o => o.value === ComparisonType.Between.toString())
                    .forEach(o => o.text = "Range");
            }
        });
    }

    public override getFilterValueDescription(value: ComparisonValue, configurationValues: Record<string, string>): string {
        if (value.comparisonType === ComparisonType.Between) {
            return `During '${this.getFilterValueText(value, configurationValues)}'`;
        }

        return super.getFilterValueDescription(value, configurationValues);
    }

    public override getFilterValueText(value: ComparisonValue, _configurationValues: Record<string, string>): string {
        const filterValues = value.value.split("\t");

        // If the comparison type is Between, then we need to use the second
        // value that was specified.
        if (value.comparisonType === ComparisonType.Between && filterValues.length > 1) {
            const range = parseSlidingDateRangeString(filterValues[1]);

            // If we couldn't parse the range information then just return
            // the raw value, which should be an empty string, but would give
            // some indication that something is wrong if it isn't.
            if (range === null) {
                return filterValues[1];
            }

            // Get the calculated values from the SlidingDateRange.
            const rangeTypeText = getRangeTypeText(range.rangeType);
            const timeUnitValue = range.timeValue ?? 1;
            const timeUnitText = getTimeUnitText(range.timeUnit ?? TimeUnit.Hour) + (timeUnitValue !== 1 ? "s" : "");

            // Format the text depending on the range type.
            if (range.rangeType === RangeType.Current) {
                return `${rangeTypeText} ${timeUnitText}`;
            }
            else if (([RangeType.Last, RangeType.Previous, RangeType.Next, RangeType.Upcoming] as number[]).includes(range.rangeType)) {
                return `${rangeTypeText} ${timeUnitValue} ${timeUnitText}`;
            }
            else {
                if (range.lowerDate && range.upperDate) {
                    return `${range.lowerDate} to ${range.upperDate}`;
                }
                else if (range.lowerDate) {
                    return `from ${range.lowerDate}`;
                }
                else if (range.upperDate) {
                    return `through ${range.upperDate}`;
                }
                else {
                    return "";
                }
            }
        }
        else {
            // If it's not a between, check if it's a "Current Date" value.
            if (this.isCurrentDateValue(filterValues[0])) {
                return `'${this.getCurrentDateText(filterValues[0])}'`;
            }

            // Nope, just use the date value specified.
            return filterValues[0] ? `'${filterValues[0]}'` : "";
        }
    }

    public override doesValueMatchFilter(value: string, filterValue: ComparisonValue, configurationValues: Record<string, string>): boolean {
        if (!filterValue.comparisonType) {
            return false;
        }

        const filterValueValues = filterValue.value.split("\t");

        // Try to parse the value as a date. If it can't be parsed then check
        // it against the Is Blank and Is Not Blank comparison types.
        const valueDate = RockDateTime.parseISO(value ?? "");

        if (filterValue.comparisonType === ComparisonType.IsBlank) {
            return valueDate === null;
        }
        else if (filterValue.comparisonType === ComparisonType.IsNotBlank) {
            return valueDate !== null;
        }
        else if (valueDate === null) {
            return false;
        }

        if (filterValue.comparisonType === ComparisonType.Between && filterValueValues.length > 1) {
            const slidingRange = parseSlidingDateRangeString(filterValueValues[1]);

            if (!slidingRange) {
                return false;
            }

            const dateRange = calculateSlidingDateRange(slidingRange);

            // check if the date range was not valid or the value is before the
            // start date and time.
            if (!dateRange.start || valueDate.toMilliseconds() < dateRange.start.toMilliseconds()) {
                return false;
            }

            if (dateRange.end && valueDate.toMilliseconds() >= dateRange.end.toMilliseconds()) {
                return false;
            }

            return true;
        }

        // Try to parse the filter date. If it can't be parsed then no match.
        const filterDate = this.getRelativeOrAbsoluteDate(filterValueValues[0]);

        if (filterDate === null) {
            return false;
        }

        // Convert the two dates into a format that we can do numeric comparison on.
        const newFilterValue: ComparisonValue = {
            comparisonType: filterValue.comparisonType,
            value: filterDate.toASPString("yyyyMMdd")
        };

        return super.doesValueMatchFilter(valueDate.toASPString("yyyyMMdd"), newFilterValue, configurationValues);
    }

    /**
     * Determines if the value is a "current date" value, which would then
     * specify the number of days +/- to adjust.
     *
     * @param value The value to be checked.
     *
     * @returns true if the value represents a "current date" value; otherwise false.
     */
    private isCurrentDateValue(value: string): boolean {
        return value.indexOf("CURRENT") === 0;
    }

    /**
     * Get the text that describes the "current date" value specified.
     *
     * @param value The value that contains the "current date" value.
     *
     * @returns A human friendly description of the "current date" value.
     */
    private getCurrentDateText(value: string): string {
        const parts = (value ?? "").split(":");
        const diff = parts.length === 2 ? toNumber(parts[1]) : 0;

        if (diff === 1) {
            return "Current Date plus 1 day";
        }
        else if (diff > 0) {
            return `Current Date plus ${diff} days`;
        }
        else if (diff === -1) {
            return "Current Date minus 1 day";
        }
        else if (diff < 0) {
            return `Current Date minus ${Math.abs(diff)} days`;
        }
        else {
            return "Current Date";
        }
    }

    /**
     * Gets the relatative date if available otherwise the absolute date.
     *
     * @param value The string value to be parsed as relative or absolute.
     *
     * @returns A new RockDateTime instance that represents the value or null if it couldn't be determined.
     */
    private getRelativeOrAbsoluteDate(value: string): RockDateTime | null {
        if (!this.isCurrentDateValue(value)) {
            return RockDateTime.parseISO(value);
        }

        const today = RockDateTime.now().date;
        const valueParts = value.split(":");

        if (valueParts.length > 1) {
            return today.addDays(toNumber(valueParts[1]));
        }

        return today;
    }
}
