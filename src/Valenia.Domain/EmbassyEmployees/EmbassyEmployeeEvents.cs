using System;

namespace Valenia.Domain.EmbassyEmployees
{
    public static class EmbassyEmployeeEvents
    {
        public class Registered
        {
            public Guid Id { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public EmbassyEmployeeRole Role { get; set; }
        }

        public class RoleUpdated
        {
            public Guid Id { get; set; }
            public EmbassyEmployeeRole Role { get; set; }
        }

        public class Fired
        {
            public Guid Id { get; set; }
        }

    }
}
