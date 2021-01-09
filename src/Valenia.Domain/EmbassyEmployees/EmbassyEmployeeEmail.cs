using System;
using Valenia.Common;
using Valenia.Domain.Shared;

namespace Valenia.Domain.EmbassyEmployees
{
    public class EmbassyEmployeeEmail : Value<EmbassyEmployeeEmail>
    {
        public string Value { get; internal set; }

        protected EmbassyEmployeeEmail() { }

        public static EmbassyEmployeeEmail FromString(string email)
        {
            CheckValidity(email);
            return new EmbassyEmployeeEmail(email);
        }

        internal EmbassyEmployeeEmail(string value) => Value = value;

        public static implicit operator string(EmbassyEmployeeEmail goal) => goal.Value;

        private static void CheckValidity(string value)
        {
            if (!value.IsValidEmail())
                throw new ArgumentException("The embassy employee email is invalid", nameof(value));
        }

        public static EmbassyEmployeeEmail NoEmail => new EmbassyEmployeeEmail();
    }
}
