using System.Collections.Generic;
using System.Threading.Tasks;
using Raven.Client.Documents;
using Raven.Client.Documents.Linq;
using Raven.Client.Documents.Session;
using Valenia.Domain.Visas;

namespace Valenia.Visas
{
    public static class Queries
    {
        public static Task<List<ReadModels.VisaDetails>> Query(
            this IAsyncDocumentSession session,
            QueryModels.GetVisaDetails query
        )
        {
            var lol = session.Query<Visa>()
                .Where(x => x.Id.Value == query.VisaId)
                .Select(
                    x =>
                        new ReadModels.VisaDetails
                        {
                            VisaId = x.Id.Value,
                            Goal = x.Goal.Value,
                            Type = x.Type,
                            ExpectedProcessingTime = x.ExpectedProcessingTime.Days
                        }
                ).ToListAsync();

            return lol;
        }
        public static Task<List<ReadModels.VisaGoal>> Query(
            this IAsyncDocumentSession session,
            QueryModels.GetVisaGoalsByType query
        ) =>
            session.Query<Visa>()
                .Where(x => x.Type == query.Type)
                .Select(
                    x =>
                        new ReadModels.VisaGoal
                        {
                            VisaId = x.Id.Value,
                            Goal = x.Goal.Value
                        }
                ).PagedList(query.Page, query.PageSize);

        public static Task<List<ReadModels.RequirementsDetails>> Query(
            this IAsyncDocumentSession session,
            QueryModels.GetVisaRequirements query
        ) =>
            session.Query<Visa>()
                .Where(x => x.Id.Value == query.VisaId)
                .Select(
                    x =>
                        new ReadModels.RequirementsDetails
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
