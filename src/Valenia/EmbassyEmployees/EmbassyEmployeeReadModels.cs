using System;
using Valenia.Domain.EmbassyEmployees;

namespace Valenia.EmbassyEmployees
{
    public static class EmbassyEmployeeReadModels
    {
        public class Details
        {
            public Guid EmbassyEmployeeId { get; set; }
            public string FullName { get; set; }
            public EmbassyEmployeeRole Role { get; set; }
        }
    }
}
