using System;

namespace Valenia.Domain.Visas.Requirements
{
    public static class RequirementEvents
    {
        public class RequirementAddedToVisa
        {
            public Guid RequirementId { get; set; }
            public Guid VisaId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Example { get; set; }
        }

        public class RequirementNameChanged
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }

        public class RequirementDescriptionChanged
        {
            public Guid Id { get; set; }
            public string Description { get; set; }
        }

        public class RequirementExampleChanged
        {
            public Guid Id { get; set; }
            public string Example { get; set; }
        }
    }
}
