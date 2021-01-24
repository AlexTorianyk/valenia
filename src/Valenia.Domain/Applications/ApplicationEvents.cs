using System;

namespace Valenia.Domain.Applications
{
    public static class ApplicationEvents
    {
        public class Submitted
        {
            public Guid Id { get; set; }
            public Guid ApplicantId { get; set; }
            public Guid VisaId { get; set; }
            public DateTimeOffset SubmissionDate { get; set; }
        }

        public class DocumentAdded
        {
            public string DocumentUrl { get; set; }
        }

        public class AssignedToReviewer
        {
            public Guid ReviewerId { get; set; }
        }

        public class ChangesRequested {}

        public class Approved {}
    }
}
