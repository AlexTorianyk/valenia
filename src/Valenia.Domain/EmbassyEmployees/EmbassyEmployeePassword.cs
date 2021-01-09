using System;
using Valenia.Common;
using Valenia.Domain.Shared;

namespace Valenia.Domain.EmbassyEmployees
{
    public class EmbassyEmployeePassword : Value<EmbassyEmployeePassword>
    {
        public string Value { get; internal set; }

        protected EmbassyEmployeePassword() { }

        public static EmbassyEmployeePassword FromString(string password, IPasswordHasher passwordHasher)
        {
            CheckValidity(password);
            return new EmbassyEmployeePassword(passwordHasher.HashPassword(password));
        }

        internal EmbassyEmployeePassword(string value) => Value = value;

        public static implicit operator string(EmbassyEmployeePassword password) => password.Value;

        private static void CheckValidity(string value)
        {
            if (value.IsEmpty())
                throw new ArgumentNullException(nameof(EmbassyEmployeePassword));

            if (value.Length < 3)
                throw new ArgumentOutOfRangeException(nameof(value), "Password is too short");
        }

        public static EmbassyEmployeePassword NoPassword => new EmbassyEmployeePassword();
    }
}
