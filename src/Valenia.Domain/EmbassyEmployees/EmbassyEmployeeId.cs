using System;
using Valenia.Common;

namespace Valenia.Domain.EmbassyEmployees
{
    public class EmbassyEmployeeId : Value<EmbassyEmployeeId>
    {
        public Guid Value { get; internal set; }
        protected EmbassyEmployeeId() { }

        public EmbassyEmployeeId(Guid value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Embassy employee id cannot be empty");

            Value = value;
        }

        public static implicit operator Guid(EmbassyEmployeeId self) => self.Value;

        public static implicit operator EmbassyEmployeeId(string value)
            => new EmbassyEmployeeId(Guid.Parse(value));

        public override string ToString() => Value.ToString();
    }
}
