using System;
using Valenia.Common;
using Valenia.Domain.Shared.Exceptions;
using Valenia.Domain.Users.Shared;

namespace Valenia.Domain.Users.EmbassyEmployees
{
    public class EmbassyEmployee : AggregateRoot<EmbassyEmployeeId>
    {
        public FullName FullName { get; set; }
        public Email Email { get; set; }
        public Password Password { get; set; }
        public EmbassyEmployeeRole Role { get; set; }

        public EmbassyEmployee(FullName fullName, Email email, Password password, EmbassyEmployeeRole role)
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
                Role = role
            });
        }

        public void Fire()
        {
            Apply(new EmbassyEmployeeEvents.Fired());
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case EmbassyEmployeeEvents.Registered e:
                    Id = new EmbassyEmployeeId(e.Id);
                    FullName = FullName.FromString(e.FullName);
                    Email = Email.FromString(e.Email);
                    Password = new Password(e.Password);
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
