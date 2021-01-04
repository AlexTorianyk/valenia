using System;
using Valenia.Common;

namespace Valenia.Domain.Visas.Requirements
{
    public class RequirementDescription : Value<RequirementDescription>
    {
        protected RequirementDescription() { }

        public static RequirementDescription FromString(string description)
        {
            CheckValidity(description);
            return new RequirementDescription(description);
        }

        public string Value { get; internal set; }

        internal RequirementDescription(string value) => Value = value;

        public static implicit operator string(RequirementDescription description) => description.Value;

        private static void CheckValidity(string value)
        {
            if (value.Length > 300)
                throw new ArgumentOutOfRangeException(nameof(value), "Requirement description cannot be longer than 300 characters");

            if (value.IsEmpty())
                throw new ArgumentNullException(nameof(RequirementDescription));
        }

        public static RequirementDescription NoDescription => new RequirementDescription();
    }
}
