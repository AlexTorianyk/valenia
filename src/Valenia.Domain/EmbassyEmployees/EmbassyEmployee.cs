using System;
using Valenia.Common;
using Valenia.Domain.Shared.Exceptions;

namespace Valenia.Domain.EmbassyEmployees
{
    public class EmbassyEmployee : AggregateRoot<EmbassyEmployeeId>
    {
        public EmbassyEmployeeFullName FullName { get; set; }
        public EmbassyEmployeeEmail Email { get; set; }
        public EmbassyEmployeePassword Password { get; set; }
        public EmbassyEmployeeRole Role { get; set; }

        public EmbassyEmployee(EmbassyEmployeeFullName fullName, EmbassyEmployeeEmail email, EmbassyEmployeePassword password, EmbassyEmployeeRole role)
        {
            Apply(new EmbassyEmployeeEvents.Registered
            {
                Id = Guid.NewGuid(),
                FullName = fullName,
                Email = email,
                Password = password,
                Role = role
            });
        }

        public void SetRole(EmbassyEmployeeRole role)
        {
            Apply(new EmbassyEmployeeEvents.RoleUpdated
            {
                Id = Id,
                Role = role
            });
        }

        public void Fire()
        {
            Apply(new EmbassyEmployeeEvents.Fired
            {
                Id = Id
            });
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case EmbassyEmployeeEvents.Registered e:
                    Id = new EmbassyEmployeeId(e.Id);
                    FullName = EmbassyEmployeeFullName.FromString(e.FullName);
                    Email = EmbassyEmployeeEmail.FromString(e.Email);
                    Password = new EmbassyEmployeePassword(e.Password);
                    Role = e.Role;
                    break;
                case EmbassyEmployeeEvents.RoleUpdated e:
                    Role = e.Role;
                    break;
                case EmbassyEmployeeEvents.Fired _:
                    Role = EmbassyEmployeeRole.Discharged;
                    break;
            }
        }

        protected override void EnsureValidState()
        {
            var valid = Id != null;

            if (!valid)
                throw new Exceptions.InvalidEntityState(this,
                    $"Post-checks failed for Embassy Employee {Id}");
        }

        private string DbId
        {
            get => $"EmbassyEmployee/{Id.Value}";
            set { }
        }

        protected EmbassyEmployee() { }
    }
}
