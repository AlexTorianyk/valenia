using System;
using Valenia.Common;

namespace Valenia.Domain.Users.Shared
{
    public class FullName : Value<FullName>
    {
        public string Value { get; internal set; }

        protected FullName() { }

        internal FullName(string value) => Value = value;

        public static FullName FromString(string fullName)
        {
            if (fullName.IsEmpty())
                throw new ArgumentNullException(nameof(fullName));

            return new FullName(fullName);
        }

        public static implicit operator string(FullName fullName)
            => fullName.Value;

        public static FullName NoFullName => new FullName();
    }
}
