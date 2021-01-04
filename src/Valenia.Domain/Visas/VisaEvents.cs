using System;

namespace Valenia.Domain.Visas
{
    public static class VisaEvents
    {
        public class VisaCreated
        {
            public Guid Id { get; set; }
            public VisaType Type { get; set; }
        }

        public class VisaGoalChanged
        {
            public Guid Id { get; set; }
            public string Goal { get; set; }
        }

        public class VisaTypeUpdated
        {
            public Guid Id { get; set; }
            public VisaType Type { get; set; }
        }

        public class VisaExceptedProcessingTimeChanged
        {
            public Guid Id { get; set; }
            public int ExceptedProcessingTime { get; set; }
        }
    }
}
