using System;
using Valenia.Common;
using Valenia.Domain.Shared.Exceptions;
using Valenia.Domain.Users.Shared;

namespace Valenia.Domain.Users.Applicants
{
    public class Applicant : AggregateRoot<ApplicantId>
    {
        public FullName FullName { get; set; }
        public Email Email { get; set; }
        public Password Password { get; set; }

        public Applicant(FullName fullName, Email email, Password password)
        {
            Apply(new ApplicantEvents.Registered
            {
                Id = Guid.NewGuid(),
                FullName = fullName,
                Email = email,
                Password = password,
            });
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case ApplicantEvents.Registered e:
                    Id = new ApplicantId(e.Id);
                    FullName = FullName.FromString(e.FullName);
                    Email = Email.FromString(e.Email);
                    Password = new Password(e.Password);
                    break;
            }
        }

        protected override void EnsureValidState()
        {
            var valid = Id != null;

            if (!valid)
                throw new Exceptions.InvalidEntityState(this,
                    $"Post-checks failed for Applicant {Id}");
        }

        private string DbId
        {
            get => $"Applicant/{Id.Value}";
            set { }
        }

        protected Applicant() { }
    }
}
