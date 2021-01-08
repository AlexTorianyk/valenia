using System;

namespace Valenia.Domain.Visas
{
    public static class VisaEvents
    {
        public class Created
        {
            public Guid Id { get; set; }
            public VisaType Type { get; set; }
        }

        public class GoalChanged
        {
            public Guid Id { get; set; }
            public string Goal { get; set; }
        }

        public class TypeUpdated
        {
            public Guid Id { get; set; }
            public VisaType Type { get; set; }
        }

        public class ExceptedProcessingTimeChanged
        {
            public Guid Id { get; set; }
            public int ExceptedProcessingTime { get; set; }
        }
    }
}
