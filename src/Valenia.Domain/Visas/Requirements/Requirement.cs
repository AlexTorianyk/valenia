using System;
using Valenia.Common;

namespace Valenia.Domain.Visas.Requirements
{
    public class Requirement : Entity<RequirementId>
    {
        public Guid RequirementId
        {
            get => Id.Value;
            set { }
        }
        protected Requirement() {}

        public RequirementName Name { get; private set; }
        public RequirementDescription Description { get; private set; }
        public RequirementExample Example { get; private set; }
        public VisaId ParentId { get; private set; }

        public void UpdateName(RequirementName name)
        {
            Apply(new RequirementEvents.NameChanged
            {
                Id = Id,
                Name = name
            });
        }

        public void UpdateDescription(RequirementDescription description)
        {
            Apply(new RequirementEvents.DescriptionChanged
            {
                Id = Id,
                Description = description
            });
        }

        public void UpdateExample(RequirementExample example)
        {
            Apply(new RequirementEvents.ExampleChanged
            {
                Id = Id,
                Example = example
            });
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case RequirementEvents.AddedToVisa e:
                    ParentId = new VisaId(e.VisaId);
                    Id = new RequirementId(e.RequirementId);
                    Name = new RequirementName(e.Name);
                    Description = new RequirementDescription(e.Description);
                    Example = new RequirementExample(e.Example);
                    break;
                case RequirementEvents.NameChanged e:
                    Name = new RequirementName(e.Name);
                    break;
                case RequirementEvents.ExampleChanged e:
                    Example = new RequirementExample(e.Example);
                    break;
                case RequirementEvents.DescriptionChanged e:
                    Description = new RequirementDescription(e.Description);
                    break;
            }
        }

        public Requirement(Action<object> applier)
            : base(applier) {}
    }
}
