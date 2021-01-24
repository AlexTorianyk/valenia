using System;
using Valenia.Common;

namespace Valenia.Domain.Applications
{
    public class SubmissionDate : Value<SubmissionDate>
    {
        private const int ONE_MONTH = 30;
        public DateTimeOffset Value { get; internal set; }

        internal SubmissionDate(DateTimeOffset value) => Value = value;

        public static SubmissionDate FromDateTimeOffset(DateTimeOffset submissionDate)
        {
            CheckValidity(submissionDate);
            return new SubmissionDate(submissionDate);
        }

        private static void CheckValidity(DateTimeOffset value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Submission date cannot be empty");

            var timeDifference = (DateTimeOffset.Now - value).Days;
            if (timeDifference > ONE_MONTH)
                throw new ArgumentOutOfRangeException(nameof(value), "An application can only be submitted to the system within 30 days.");
        }

        public static implicit operator DateTimeOffset(SubmissionDate submissionDate)
            => submissionDate.Value;

        protected SubmissionDate() {}
    }
}
