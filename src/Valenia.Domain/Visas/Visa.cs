using System;
using System.Collections.Generic;
using System.Linq;
using Valenia.Common;
using Valenia.Domain.Shared.Exceptions;
using Valenia.Domain.Visas.Requirements;

namespace Valenia.Domain.Visas
{
    public class Visa : AggregateRoot<VisaId>
    {
        private string DbId
        {
            get => $"Visa/{Id.Value}";
            set { }
        }

        protected Visa()
        {
        }

        public VisaGoal Goal { get; set; }
        public VisaType Type { get; set; }
        public VisaExpectedProcessingTime ExpectedProcessingTime { get; set; }
        public List<Requirement> Requirements { get; set; }

        public Visa(VisaId id, VisaType type)
        {
            Requirements = new List<Requirement>();
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
            Apply(new RequirementEvents.NameChanged{
                Id = requirementId,
                Name = name
            });
        }

        public void UpdateRequirementDescription(RequirementId requirementId, RequirementDescription description)
        {
            Apply(new RequirementEvents.DescriptionChanged
            {
                Id = requirementId,
                Description = description
            });
        }

        public void UpdateRequirementExample(RequirementId requirementId, RequirementExample example)
        {
            Apply(new RequirementEvents.ExampleChanged
            {
                Id = requirementId,
                Example = example
            });
        }

        protected override void When(object @event)
        {
            Requirement requirement;
            switch (@event)
            {
                case VisaEvents.Created e:
                    Id = new VisaId(e.Id);
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
                    requirement = new Requirement(Apply);
                    ApplyToEntity(requirement, e);
                    Requirements.Add(requirement);
                    break;
                case RequirementEvents.NameChanged e:
                    requirement = FindRequirement(new RequirementId(e.Id));
                    ApplyToEntity(requirement, e);
                    break;
                case RequirementEvents.ExampleChanged e:
                    requirement = FindRequirement(new RequirementId(e.Id));
                    ApplyToEntity(requirement, e);
                    break;
                case RequirementEvents.DescriptionChanged e:
                    requirement = FindRequirement(new RequirementId(e.Id));
                    ApplyToEntity(requirement, e);
                    break;
            }
        }

        protected override void EnsureValidState()
        {
            var valid = Id != null;
            if (!Requirements.Any()) return;
            if (ExpectedProcessingTime == VisaExpectedProcessingTime.NoExpectedProcessingTime)
            {
                valid = false;
            }

            if (!valid)
                throw new Exceptions.InvalidEntityState(this,
                    $"Post-checks failed for Visa {Id}");
        }

        private Requirement FindRequirement(RequirementId id)
        {
            var requirement = Requirements.FirstOrDefault(r => r.Id == id);
            if (requirement == null)
                throw new InvalidOperationException("Cannot update a non-existing requirement");

            return requirement;
        }

    }
}