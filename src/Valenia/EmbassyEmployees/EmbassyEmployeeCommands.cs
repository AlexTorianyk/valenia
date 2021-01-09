using System;
using Valenia.Domain.EmbassyEmployees;

namespace Valenia.EmbassyEmployees
{
    public class EmbassyEmployeeCommands
    {
        public class Register
        {
            public string FullName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public EmbassyEmployeeRole Role { get; set; }
        }

        public class UpdateRole
        {
            public Guid Id { get; set; }
            public EmbassyEmployeeRole Role { get; set; }
        }

        public class Fire
        {
            public Guid Id { get; set; }
        }
    }
}
