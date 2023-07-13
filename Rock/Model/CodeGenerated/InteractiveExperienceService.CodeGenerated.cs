//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Rock.CodeGeneration project
//     Changes to this file will be lost when the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
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

using System;
using System.Linq;

using Rock.Data;

namespace Rock.Model
{
    /// <summary>
    /// InteractiveExperience Service class
    /// </summary>
    public partial class InteractiveExperienceService : Service<InteractiveExperience>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InteractiveExperienceService"/> class
        /// </summary>
        /// <param name="context">The context.</param>
        public InteractiveExperienceService(RockContext context) : base(context)
        {
        }

        /// <summary>
        /// Determines whether this instance can delete the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <returns>
        ///   <c>true</c> if this instance can delete the specified item; otherwise, <c>false</c>.
        /// </returns>
        public bool CanDelete( InteractiveExperience item, out string errorMessage )
        {
            errorMessage = string.Empty;
            return true;
        }
    }

    /// <summary>
    /// Generated Extension Methods
    /// </summary>
    public static partial class InteractiveExperienceExtensionMethods
    {
        /// <summary>
        /// Clones this InteractiveExperience object to a new InteractiveExperience object
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="deepCopy">if set to <c>true</c> a deep copy is made. If false, only the basic entity properties are copied.</param>
        /// <returns></returns>
        public static InteractiveExperience Clone( this InteractiveExperience source, bool deepCopy )
        {
            if (deepCopy)
            {
                return source.Clone() as InteractiveExperience;
            }
            else
            {
                var target = new InteractiveExperience();
                target.CopyPropertiesFrom( source );
                return target;
            }
        }

        /// <summary>
        /// Clones this InteractiveExperience object to a new InteractiveExperience object with default values for the properties in the Entity and Model base classes.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static InteractiveExperience CloneWithoutIdentity( this InteractiveExperience source )
        {
            var target = new InteractiveExperience();
            target.CopyPropertiesFrom( source );

            target.Id = 0;
            target.Guid = Guid.NewGuid();
            target.ForeignKey = null;
            target.ForeignId = null;
            target.ForeignGuid = null;
            target.CreatedByPersonAliasId = null;
            target.CreatedDateTime = RockDateTime.Now;
            target.ModifiedByPersonAliasId = null;
            target.ModifiedDateTime = RockDateTime.Now;

            return target;
        }

        /// <summary>
        /// Copies the properties from another InteractiveExperience object to this InteractiveExperience object
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="source">The source.</param>
        public static void CopyPropertiesFrom( this InteractiveExperience target, InteractiveExperience source )
        {
            target.Id = source.Id;
            target.ActionBackgroundColor = source.ActionBackgroundColor;
            target.ActionBackgroundImageBinaryFileId = source.ActionBackgroundImageBinaryFileId;
            target.ActionCustomCss = source.ActionCustomCss;
            target.ActionPrimaryButtonColor = source.ActionPrimaryButtonColor;
            target.ActionPrimaryButtonTextColor = source.ActionPrimaryButtonTextColor;
            target.ActionSecondaryButtonColor = source.ActionSecondaryButtonColor;
            target.ActionSecondaryButtonTextColor = source.ActionSecondaryButtonTextColor;
            target.ActionTextColor = source.ActionTextColor;
            target.AudienceAccentColor = source.AudienceAccentColor;
            target.AudienceBackgroundColor = source.AudienceBackgroundColor;
            target.AudienceBackgroundImageBinaryFileId = source.AudienceBackgroundImageBinaryFileId;
            target.AudienceCustomCss = source.AudienceCustomCss;
            target.AudiencePrimaryColor = source.AudiencePrimaryColor;
            target.AudienceSecondaryColor = source.AudienceSecondaryColor;
            target.AudienceTextColor = source.AudienceTextColor;
            target.Description = source.Description;
            target.ExperienceSettingsJson = source.ExperienceSettingsJson;
            target.ForeignGuid = source.ForeignGuid;
            target.ForeignKey = source.ForeignKey;
            target.IsActive = source.IsActive;
            target.Name = source.Name;
            target.NoActionHeaderImageBinaryFileId = source.NoActionHeaderImageBinaryFileId;
            target.NoActionMessage = source.NoActionMessage;
            target.NoActionTitle = source.NoActionTitle;
            target.PhotoBinaryFileId = source.PhotoBinaryFileId;
            target.PublicLabel = source.PublicLabel;
            target.PushNotificationDetail = source.PushNotificationDetail;
            target.PushNotificationTitle = source.PushNotificationTitle;
            target.PushNotificationType = source.PushNotificationType;
            target.WelcomeHeaderImageBinaryFileId = source.WelcomeHeaderImageBinaryFileId;
            target.WelcomeMessage = source.WelcomeMessage;
            target.WelcomeTitle = source.WelcomeTitle;
            target.CreatedDateTime = source.CreatedDateTime;
            target.ModifiedDateTime = source.ModifiedDateTime;
            target.CreatedByPersonAliasId = source.CreatedByPersonAliasId;
            target.ModifiedByPersonAliasId = source.ModifiedByPersonAliasId;
            target.Guid = source.Guid;
            target.ForeignId = source.ForeignId;

        }
    }
}
