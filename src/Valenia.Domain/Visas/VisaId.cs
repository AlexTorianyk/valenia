using System;
using Valenia.Common;

namespace Valenia.Domain.Visas
{
    public class VisaId : Value<VisaId>
    {
        public Guid Value { get; internal set; }
        protected VisaId() { }

        public VisaId(Guid value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Visa Ad id cannot be empty");

            Value = value;
        }

        public static implicit operator Guid(VisaId self) => self.Value;

        public static implicit operator VisaId(string value)
            => new VisaId(Guid.Parse(value));

        public override string ToString() => Value.ToString();
    }
}
