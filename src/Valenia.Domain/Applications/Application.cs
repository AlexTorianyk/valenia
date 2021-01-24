using System;
using System.Collections.Generic;
using System.Linq;
using Valenia.Common;
using Valenia.Domain.Shared.Exceptions;
using Valenia.Domain.Users.Applicants;
using Valenia.Domain.Users.EmbassyEmployees;
using Valenia.Domain.Visas;

namespace Valenia.Domain.Applications
{
    public class Application : AggregateRoot<ApplicationId>
    {
        public ApplicantId ApplicantId { get; private set; }
        public EmbassyEmployeeId ReviewerId { get; private set; }
        public VisaId VisaId { get; private set; }
        public SubmissionDate SubmissionDate { get; private set; }
        public ApplicationStatus Status { get; private set; }
        public List<Uri> Documents { get; private set; }

        public Application(ApplicantId applicantId, VisaId visaId, SubmissionDate submissionDate)
        {
            Documents = new List<Uri>();
            Apply(new ApplicationEvents.Submitted
            {
                Id = Guid.NewGuid(),
                ApplicantId = applicantId,
                VisaId = visaId,
                SubmissionDate = submissionDate ?? DateTimeOffset.Now
            });
        }

        public void AddDocument(Uri documentUrl)
        {
            Apply(new ApplicationEvents.DocumentAdded
            {
                DocumentUrl = documentUrl.ToString()
            });
        }

        public void AssignToReviewer(EmbassyEmployeeId reviewerId)
        {
            Apply(new ApplicationEvents.AssignedToReviewer
            {
                ReviewerId = reviewerId
            });
        }

        public void RequestChanges()
        {
            Apply(new ApplicationEvents.ChangesRequested());
        }

        public void Approve()
        {
            Apply(new ApplicationEvents.Approved());
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case ApplicationEvents.Submitted e:
                    Id = new ApplicationId(e.Id);
                    ApplicantId = new ApplicantId(e.ApplicantId);
                    VisaId = new VisaId(e.VisaId);
                    SubmissionDate = SubmissionDate.FromDateTimeOffset(e.SubmissionDate);
                    Status = ApplicationStatus.Submitted;
                    break;
                case ApplicationEvents.AssignedToReviewer e:
                    ReviewerId = new EmbassyEmployeeId(e.ReviewerId);
                    Status = ApplicationStatus.PendingForReview;
                    break;
                case ApplicationEvents.DocumentAdded e:
                    var document = new Uri(e.DocumentUrl);
                    Documents.Add(document);
                    break;
                case ApplicationEvents.ChangesRequested _:
                    Status = ApplicationStatus.ChangesRequested;
                    break;
                case ApplicationEvents.Approved _:
                    Status = ApplicationStatus.Approved;
                    break;
            }
        }

        protected override void EnsureValidState()
        {
            var valid = Id != null && ApplicantId != null && VisaId != null && SubmissionDate != default
                        && Status switch
                        {
                            ApplicationStatus.PendingForReview => ReviewerId != null && Documents.Any(),
                            ApplicationStatus.Approved => ReviewerId != null && Documents.Any(),
                            _ => true
                        };

            if (!valid)
                throw new Exceptions.InvalidEntityState(this,
                    $"Post-checks failed for Application {Id}");
        }

        private string DbId
        {
            get => $"Application/{Id.Value}";
            set { }
        }

        protected Application() { }
    }
}
