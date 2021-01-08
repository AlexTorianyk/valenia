using System;
using Valenia.Domain.Visas;

namespace Valenia.Visas
{
    public static class QueryModels
    {
        public class GetVisaDetails
        {
            public Guid VisaId { get; set; }
        }

        public class GetVisaGoalsByType
        {
            public int Page { get; set; }
            public int PageSize { get; set; }
            public VisaType Type { get; set; }
        }

        public class GetVisaRequirements
        {
            public Guid VisaId { get; set; }
        }
    }
}
