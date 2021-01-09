using System;
using Valenia.Common;
using Valenia.Domain.Shared;

namespace Valenia.Domain.Users.Shared
{
    public class Email : Value<Email>
    {
        public string Value { get; internal set; }

        protected Email() { }

        public static Email FromString(string email)
        {
            CheckValidity(email);
            return new Email(email);
        }

        internal Email(string value) => Value = value;

        public static implicit operator string(Email goal) => goal.Value;

        private static void CheckValidity(string value)
        {
            if (!value.IsValidEmail())
                throw new ArgumentException("The embassy employee email is invalid", nameof(value));
        }

        public static Email NoEmail => new Email();
    }
}
