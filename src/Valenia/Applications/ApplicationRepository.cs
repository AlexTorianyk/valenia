using Raven.Client.Documents.Session;
using Valenia.Domain.Applications;
using Valenia.Infrastructure.Application.AutomaticDependencyInjection;
using Valenia.Infrastructure.Persistence;
using ApplicationId = Valenia.Domain.Applications.ApplicationId;

namespace Valenia.Applications
{
    public class ApplicationRepository : RavenDbRepository<Application, ApplicationId>, IApplicationRepository, IScoped
    {
        public ApplicationRepository(IAsyncDocumentSession session) : base(session, id => $"Application/{id.Value}")
        {
        }
    }
}
