System.register([], function (exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    // <copyright>
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
    /**
     * Get a formatted string.
     * Ex: 10001.2 => 10,001.2
     * @param num
     */
    function asFormattedString(num, digits) {
        if (digits === void 0) { digits = 2; }
        if (num === null) {
            return '';
        }
        return num.toLocaleString('en-US', {
            minimumFractionDigits: digits,
            maximumFractionDigits: digits
        });
    }
    exports_1("asFormattedString", asFormattedString);
    /**
     * Get a number value from a formatted string.
     * Ex: $1,000.20 => 1000.2
     * @param str
     */
    function toNumberOrNull(str) {
        if (str === null) {
            return null;
        }
        var replaced = str.replace(/[$,]/g, '');
        return Number(replaced) || 0;
    }
    exports_1("toNumberOrNull", toNumberOrNull);
    /**
     * Adds an ordinal suffix.
     * Ex: 1 => 1st
     * @param num
     */
    function toOrdinalSuffix(num) {
        if (!num) {
            return '';
        }
        var j = num % 10;
        var k = num % 100;
        if (j == 1 && k != 11) {
            return num + 'st';
        }
        if (j == 2 && k != 12) {
            return num + 'nd';
        }
        if (j == 3 && k != 13) {
            return num + 'rd';
        }
        return num + 'th';
    }
    exports_1("toOrdinalSuffix", toOrdinalSuffix);
    /**
     * Convert a number to an ordinal.
     * Ex: 1 => First
     * @param num
     */
    function toOrdinal(num) {
        if (!num) {
            return '';
        }
        switch (num) {
            case 1: return 'first';
            case 2: return 'second';
            case 3: return 'third';
            case 4: return 'fourth';
            case 5: return 'fifth';
            case 6: return 'sixth';
            case 7: return 'seventh';
            case 8: return 'eighth';
            case 9: return 'ninth';
            case 10: return 'tenth';
            default: return toOrdinalSuffix(num);
        }
    }
    exports_1("toOrdinal", toOrdinal);
    return {
        setters: [],
        execute: function () {
            exports_1("default", {
                toOrdinal: toOrdinal,
                toOrdinalSuffix: toOrdinalSuffix,
                toNumberOrNull: toNumberOrNull,
                asFormattedString: asFormattedString
            });
        }
    };
});
//# sourceMappingURL=Number.js.map