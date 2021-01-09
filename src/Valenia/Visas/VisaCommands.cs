using System;
using Valenia.Domain.Visas;

namespace Valenia.Visas
{
    public static class VisaCommands
    {
        public class Create
        {
            public VisaType Type { get; set; }
        }

        public class SetGoal
        {
            public Guid Id { get; set; }
            public string Goal { get; set; }
        }

        public class UpdateType
        {
            public Guid Id { get; set; }
            public VisaType Type { get; set; }
        }

        public class SetExpectedProcessingTime
        {
            public Guid Id { get; set; }
            public int ExceptedProcessingTime { get; set; }
        }
    }

    public static class RequirementCommands
    {
        public class AddToVisa
        {
            public Guid VisaId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Example { get; set; }
        }

        public class UpdateName
        {
            public Guid RequirementId { get; set; }
            public Guid VisaId { get; set; }
            public string Name { get; set; }
        }

        public class UpdateDescription
        {
            public Guid RequirementId { get; set; }
            public Guid VisaId { get; set; }
            public string Description { get; set; }
        }

        public class UpdateExample
        {
            public Guid RequirementId { get; set; }
            public Guid VisaId { get; set; }
            public string Example { get; set; }
        }
    }
}
