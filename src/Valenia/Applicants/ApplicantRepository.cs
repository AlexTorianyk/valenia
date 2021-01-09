using Raven.Client.Documents.Session;
using Valenia.Domain.Users.Applicants;
using Valenia.Infrastructure.Application.AutomaticDependencyInjection;
using Valenia.Infrastructure.Persistence;

namespace Valenia.Applicants
{
    public class ApplicantRepository : RavenDbRepository<Applicant, ApplicantId>, IApplicantRepository, IScoped
    {
        protected ApplicantRepository(IAsyncDocumentSession session)
            : base(session, id => $"Applicant/{id.Value}")
        {
        }
    }
}
