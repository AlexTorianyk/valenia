using System;

namespace Valenia.Domain.Users.Applicants
{
    public static class ApplicantEvents
    {
        public class Registered
        {
            public Guid Id { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}
