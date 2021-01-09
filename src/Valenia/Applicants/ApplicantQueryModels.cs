using System;

namespace Valenia.Applicants
{
    public static class ApplicantQueryModels
    {
        public class GetDetails
        {
            public Guid ApplicantId { get; set; }
        }
    }
}
