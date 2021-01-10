using System;
using Valenia.Common;
using Valenia.Domain.Shared;

namespace Valenia.Domain.Users.Shared
{
    public class Password : Value<Password>
    {
        public string Value { get; internal set; }

        protected Password() { }

        public static Password FromString(string password, IPasswordHasher passwordHasher)
        {
            CheckValidity(password);
            return new Password(passwordHasher.HashPassword(password));
        }

        internal Password(string value) => Value = value;

        public static implicit operator string(Password password) => password.Value;

        private static void CheckValidity(string value)
        {
            if (value.IsEmpty())
                throw new ArgumentNullException(nameof(Password));

            if (value.Length < 3)
                throw new ArgumentOutOfRangeException(nameof(value), "Password is too short");
        }

        public static Password NoPassword => new Password();
    }
}
