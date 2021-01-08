using System;

namespace Valenia.Domain.Visas.Requirements
{
    public static class RequirementEvents
    {
        public class AddedToVisa
        {
            public Guid RequirementId { get; set; }
            public Guid VisaId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Example { get; set; }
        }

        public class NameChanged
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }

        public class DescriptionChanged
        {
            public Guid Id { get; set; }
            public string Description { get; set; }
        }

        public class ExampleChanged
        {
            public Guid Id { get; set; }
            public string Example { get; set; }
        }
    }
}
