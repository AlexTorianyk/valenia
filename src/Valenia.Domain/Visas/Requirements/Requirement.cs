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
            Apply(new RequirementEvents.RequirementNameChanged
            {
                Id = Id,
                Name = name
            });
        }

        public void UpdateDescription(RequirementDescription description)
        {
            Apply(new RequirementEvents.RequirementDescriptionChanged
            {
                Id = Id,
                Description = description
            });
        }

        public void UpdateExample(RequirementExample example)
        {
            Apply(new RequirementEvents.RequirementExampleChanged
            {
                Id = Id,
                Example = example
            });
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case RequirementEvents.RequirementAddedToVisa e:
                    ParentId = new VisaId(e.VisaId);
                    Id = new RequirementId(e.RequirementId);
                    Name = new RequirementName(e.Name);
                    Description = new RequirementDescription(e.Description);
                    Example = new RequirementExample(e.Example);
                    break;
                case RequirementEvents.RequirementNameChanged e:
                    Name = new RequirementName(e.Name);
                    break;
                case RequirementEvents.RequirementExampleChanged e:
                    Example = new RequirementExample(e.Example);
                    break;
                case RequirementEvents.RequirementDescriptionChanged e:
                    Description = new RequirementDescription(e.Description);
                    break;
            }
        }

        public Requirement(Action<object> applier)
            : base(applier) {}
    }
}
