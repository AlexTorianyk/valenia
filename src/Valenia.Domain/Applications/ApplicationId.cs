using System;
using Valenia.Common;

namespace Valenia.Domain.Applications
{
    public class ApplicationId : Value<ApplicationId>
    {
        public Guid Value { get; internal set; }
        protected ApplicationId() { }

        public ApplicationId(Guid value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Application id cannot be empty");

            Value = value;
        }

        public static implicit operator Guid(ApplicationId self) => self.Value;

        public static implicit operator ApplicationId(string value)
            => new ApplicationId(Guid.Parse(value));

        public override string ToString() => Value.ToString();
    }
}
