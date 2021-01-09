using System;
using Valenia.Common;

namespace Valenia.Domain.Visas.Requirements
{
    public class RequirementExample : Value<RequirementExample>
    {
        protected RequirementExample() { }

        public static RequirementExample FromString(string example)
        {
            CheckValidity(example);
            return new RequirementExample(example);
        }

        public string Value { get; internal set; }

        internal RequirementExample(string value) => Value = value;

        public static implicit operator string(RequirementExample example) => example.Value;

        private static void CheckValidity(string value)
        {
            if (value.Length > 100)
                throw new ArgumentOutOfRangeException(nameof(value), "Requirement example cannot be longer than 100 characters");

            if (value.IsEmpty())
                throw new ArgumentNullException(nameof(RequirementExample));
        }

        public static RequirementExample NoExample => new RequirementExample();
    }
}
