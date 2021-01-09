using System;
using Valenia.Common;

namespace Valenia.Domain.Visas.Requirements
{
    public class RequirementId : Value<RequirementId>
    {
        public Guid Value { get; internal set; }
        protected RequirementId() { }
        public RequirementId(Guid value) => Value = value;

        public static implicit operator Guid(RequirementId self) => self.Value;

        public static implicit operator RequirementId(string value)
            => new RequirementId(Guid.Parse(value));

        public override string ToString() => Value.ToString();
    }
}
