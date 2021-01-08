using System;
using System.Collections.Generic;
using System.Linq;
using Valenia.Common;
using Valenia.Domain.Visas.Requirements;

namespace Valenia.Domain.Visas
{
    public class Visa : AggregateRoot<VisaId>
    {
        public Guid VisaId { get; private set; }

        protected Visa() {}

        public VisaGoal Goal { get; set; }
        public VisaType Type { get; set; }
        public VisaExpectedProcessingTime ExpectedProcessingTime { get; set; }
        public List<Requirement> Requirements { get; set; } = new List<Requirement>();

        public Visa(VisaId id, VisaType type)
        {
            Apply(new VisaEvents.Created
            {
                Id = id,
                Type = type
            });
        }

        public void SetGoal(VisaGoal goal)
        {
            Apply(new VisaEvents.GoalChanged
            {
                Id = Id,
                Goal = goal
            });
        }

        public void UpdateType(VisaType type)
        {
            Apply(new VisaEvents.TypeUpdated
            {
                Id = Id,
                Type = type
            });
        }

        public void SetExpectedProcessingTime(VisaExpectedProcessingTime expectedProcessingTime)
        {
            Apply(new VisaEvents.ExceptedProcessingTimeChanged
            {
                Id = Id,
                ExceptedProcessingTime = expectedProcessingTime.Days
            });
        }

        public void AddRequirement(RequirementName name, RequirementDescription description, RequirementExample example)
        {
            Apply(new RequirementEvents.AddedToVisa
            {
                RequirementId = Guid.NewGuid(),
                VisaId = Id,
                Name = name,
                Description = description,
                Example = example
            });
        }

        public void UpdateRequirementName(RequirementId requirementId, RequirementName name)
        {
            var requirement = FindRequirement(requirementId);
            if (requirement == null)
                throw new InvalidOperationException("Cannot update the name of a non-existing requirement");

            requirement.UpdateName(name);
        }

        public void UpdateRequirementDescription(RequirementId requirementId, RequirementDescription description)
        {
            var requirement = FindRequirement(requirementId);
            if (requirement == null)
                throw new InvalidOperationException("Cannot update the description of a non-existing requirement");

            requirement.UpdateDescription(description);
        }

        public void UpdateRequirementExample(RequirementId requirementId, RequirementExample example)
        {
            var requirement = FindRequirement(requirementId);
            if (requirement == null)
                throw new InvalidOperationException("Cannot update the example of a non-existing requirement");

            requirement.UpdateExample(example);
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case VisaEvents.Created e:
                    Id = new VisaId(e.Id);
                    VisaId = e.Id;
                    Type = e.Type;
                    Goal = VisaGoal.NoGoal;
                    ExpectedProcessingTime = VisaExpectedProcessingTime.NoExpectedProcessingTime;
                    break;
                case VisaEvents.GoalChanged e:
                    Goal = new VisaGoal(e.Goal);
                    break;
                case VisaEvents.TypeUpdated e:
                    Type = e.Type;
                    break;
                case VisaEvents.ExceptedProcessingTimeChanged e:
                    ExpectedProcessingTime = new VisaExpectedProcessingTime(e.ExceptedProcessingTime);
                    break;
                case RequirementEvents.AddedToVisa e:
                    var requirement = new Requirement(Apply);
                    ApplyToEntity(requirement, e);
                    Requirements.Add(requirement);
                    break;
            }
        }

        protected override void EnsureValidState()
        {
            //
        }

        private Requirement FindRequirement(RequirementId id) => Requirements.FirstOrDefault(r => r.Id == id);
    }
}
