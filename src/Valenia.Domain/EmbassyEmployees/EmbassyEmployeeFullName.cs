using System;
using Valenia.Common;

namespace Valenia.Domain.EmbassyEmployees
{
    public class EmbassyEmployeeFullName : Value<EmbassyEmployeeFullName>
    {
        public string Value { get; internal set; }

        protected EmbassyEmployeeFullName() { }

        internal EmbassyEmployeeFullName(string value) => Value = value;

        public static EmbassyEmployeeFullName FromString(string fullName)
        {
            if (fullName.IsEmpty())
                throw new ArgumentNullException(nameof(fullName));

            return new EmbassyEmployeeFullName(fullName);
        }

        public static implicit operator string(EmbassyEmployeeFullName fullName)
            => fullName.Value;

        public static EmbassyEmployeeFullName NoFullName => new EmbassyEmployeeFullName();
    }
}
