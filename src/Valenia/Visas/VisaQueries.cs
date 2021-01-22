using System.Collections.Generic;
using System.Threading.Tasks;
using Raven.Client.Documents;
using Raven.Client.Documents.Linq;
using Raven.Client.Documents.Session;
using Valenia.Domain.Visas;

namespace Valenia.Visas
{
    public static class VisaQueries
    {
        public static Task<VisaReadModels.Details> Query(
            this IAsyncDocumentSession session,
            VisaQueryModels.GetDetails query
        )
        {
           return session.Query<Visa>()
                .Where(x => x.Id.Value == query.VisaId)
                .Select(
                    x =>
                        new VisaReadModels.Details
                        {
                            VisaId = x.Id.Value,
                            Goal = x.Goal.Value,
                            Type = x.Type,
                            ExpectedProcessingTime = x.ExpectedProcessingTime.Days
                        }
                ).SingleAsync();
        }

        public static Task<List<VisaReadModels.Goals>> Query(
            this IAsyncDocumentSession session,
            VisaQueryModels.GetGoalsByType query
        ) =>
            session.Query<Visa>()
                .Where(x => x.Type == query.Type)
                .Select(
                    x =>
                        new VisaReadModels.Goals
                        {
                            VisaId = x.Id.Value,
                            Goal = x.Goal.Value
                        }
                ).PagedList(query.Page, query.PageSize);

        public static Task<List<VisaReadModels.RequirementsDetails>> Query(
            this IAsyncDocumentSession session,
            VisaQueryModels.GetRequirements query
        ) =>
            session.Query<Visa>()
                .Where(x => x.Id.Value == query.VisaId)
                .Select(
                    x =>
                        new VisaReadModels.RequirementsDetails
                        {
                            VisaId = x.Id.Value,
                            ExpectedProcessingTime = x.ExpectedProcessingTime.Days,
                            Requirements = x.Requirements
                        }
                ).ToListAsync();

        private static Task<List<T>> PagedList<T>(
            this IRavenQueryable<T> query, int page, int pageSize
        ) =>
            query
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToListAsync();
    }
}
