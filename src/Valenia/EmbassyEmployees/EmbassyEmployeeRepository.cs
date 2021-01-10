using Raven.Client.Documents.Session;
using Valenia.Domain.Users.EmbassyEmployees;
using Valenia.Infrastructure.Application.AutomaticDependencyInjection;
using Valenia.Infrastructure.Persistence;

namespace Valenia.EmbassyEmployees
{
    public class EmbassyEmployeeRepository : RavenDbRepository<EmbassyEmployee, EmbassyEmployeeId>, IEmbassyEmployeeRepository, IScoped
    {
        public EmbassyEmployeeRepository(IAsyncDocumentSession session)
            : base(session, id => $"EmbassyEmployee/{id.Value}")
        {
        }
    }
}
