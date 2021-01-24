using System;

namespace Valenia.Applications
{
    public static class ApplicationCommands
    {
        public class Submit
        {
            public Guid ApplicantId { get; set; }
            public Guid VisaId { get; set; }
            public DateTimeOffset SubmissionDate { get; set; }
        }

        public class AddDocument
        {
            public Guid Id { get; set; }
            public string DocumentUrl { get; set; }
        }

        public class AssignToReviewer
        {
            public Guid Id { get; set; }
            public Guid ReviewerId { get; set; }
        }

        public class RequestChanges
        {
            public Guid Id { get; set; }
        }

        public class Approve
        {
            public Guid Id { get; set; }
        }
    }
}
