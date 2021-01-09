using System;
using Valenia.Domain.Visas;

namespace Valenia.Visas
{
    public static class VisaQueryModels
    {
        public class GetDetails
        {
            public Guid VisaId { get; set; }
        }

        public class GetGoalsByType
        {
            public int Page { get; set; }
            public int PageSize { get; set; }
            public VisaType Type { get; set; }
        }

        public class GetRequirements
        {
            public Guid VisaId { get; set; }
        }
    }
}
