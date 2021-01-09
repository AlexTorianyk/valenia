using System;
using Valenia.Common;

namespace Valenia.Domain.Users.Applicants
{
    public class ApplicantId : Value<ApplicantId>
    {
        public Guid Value { get; internal set; }
        protected ApplicantId() { }

        public ApplicantId(Guid value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Applicant id cannot be empty");

            Value = value;
        }

        public static implicit operator Guid(ApplicantId self) => self.Value;

        public static implicit operator ApplicantId(string value)
            => new ApplicantId(Guid.Parse(value));

        public override string ToString() => Value.ToString();
    }
}
