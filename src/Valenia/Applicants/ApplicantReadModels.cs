using System;

namespace Valenia.Applicants
{
    public static class ApplicantReadModels
    {
        public class Details
        {
            public Guid ApplicantId { get; set; }
            public string FullName { get; set; }
        }
    }
}
