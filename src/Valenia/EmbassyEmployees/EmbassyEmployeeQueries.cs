using System.Linq;
using System.Threading.Tasks;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using Valenia.Domain.Users.EmbassyEmployees;

namespace Valenia.EmbassyEmployees
{
    public static class EmbassyEmployeeQueries
    {
        public static Task<EmbassyEmployeeReadModels.Details> Query(
            this IAsyncDocumentSession session,
            EmbassyEmployeeQueryModels.GetDetails query
        )
        {
            return session.Query<EmbassyEmployee>()
                .Where(x => x.Id.Value == query.EmbassyEmployeeId)
                .Select(
                    x =>
                        new EmbassyEmployeeReadModels.Details
                        {
                            EmbassyEmployeeId = x.Id.Value,
                            FullName = x.FullName.Value,
                            Role = x.Role
                        }
                ).SingleAsync();
        }
    }
}
