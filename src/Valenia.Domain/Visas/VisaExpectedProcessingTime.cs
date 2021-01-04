using System;
using Valenia.Common;

namespace Valenia.Domain.Visas
{
    public class VisaExpectedProcessingTime : Value<VisaExpectedProcessingTime>
    {
        public int Days { get; internal set; }

        protected VisaExpectedProcessingTime() { }
        public VisaExpectedProcessingTime(int days)
        {
            CheckValidity(days);
            Days = days;
        }

        public static VisaExpectedProcessingTime FromString(string days)
        {
            return new VisaExpectedProcessingTime(int.Parse(days));
        }

        public static VisaExpectedProcessingTime FromInt(int days)
        {
            return new VisaExpectedProcessingTime(days);
        }

        private static void CheckValidity(int value)
        {
            if (value > 1000)
                throw new ArgumentOutOfRangeException(nameof(value), "Expected visa processing time cannot be longer than 1000 days");

            if (value < 1)
                throw new ArgumentException("Expected visa processing time cannot be zero or negative", nameof(value));
        }

        public static VisaExpectedProcessingTime NoExpectedProcessingTime => new VisaExpectedProcessingTime {Days = -1};
    }
}
