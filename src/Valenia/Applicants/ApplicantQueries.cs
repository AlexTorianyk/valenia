using System.Linq;
using System.Threading.Tasks;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using Valenia.Domain.Users.Applicants;

namespace Valenia.Applicants
{
    public static class ApplicantQueries
    {
        public static Task<ApplicantReadModels.Details> Query(
            this IAsyncDocumentSession session,
            ApplicantQueryModels.GetDetails query
        )
        {
            return session.Query<Applicant>()
                .Where(x => x.Id.Value == query.ApplicantId)
                .Select(
                    x =>
                        new ApplicantReadModels.Details
                        {
                            ApplicantId = x.Id.Value,
                            FullName = x.FullName.Value
                        }
                ).SingleAsync();
        }
    }
}
