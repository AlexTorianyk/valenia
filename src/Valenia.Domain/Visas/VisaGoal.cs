using System;
using Valenia.Common;

namespace Valenia.Domain.Visas
{
    public class VisaGoal : Value<VisaGoal>
    {
        public string Value { get; internal set; }

        protected VisaGoal() { }

        public static VisaGoal FromString(string goal)
        {
            CheckValidity(goal);
            return new VisaGoal(goal);
        }

        internal VisaGoal(string value) => Value = value;

        public static implicit operator string(VisaGoal goal) => goal.Value;

        private static void CheckValidity(string value)
        {
            if (value.Length > 100)
                throw new ArgumentOutOfRangeException(nameof(value), "Visa goal cannot be longer than 100 characters");

            if (value.IsEmpty())
                throw new ArgumentNullException(nameof(VisaGoal));
        }

        public static VisaGoal NoGoal => new VisaGoal();
    }
}
