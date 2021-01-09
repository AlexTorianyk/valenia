using System;
using Valenia.Common;

namespace Valenia.Domain.Visas.Requirements
{
    public class RequirementName : Value<RequirementName>
    {
        protected RequirementName() {}

        public static RequirementName FromString(string name)
        {
            CheckValidity(name);
            return new RequirementName(name);
        }

        public string Value { get; internal set; }

        internal RequirementName(string value) => Value = value;

        public static implicit operator string(RequirementName name) => name.Value;

        private static void CheckValidity(string value)
        {
            if (value.IsEmpty())
                throw new ArgumentNullException(nameof(RequirementName));

            if (value.Length > 100)
                throw new ArgumentOutOfRangeException(nameof(value), "Requirement name cannot be longer than 100 characters");
        }

        public static RequirementName NoName => new RequirementName();
    }
}
