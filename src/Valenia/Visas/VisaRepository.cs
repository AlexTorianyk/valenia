using Raven.Client.Documents.Session;
using Valenia.Domain.Visas;
using Valenia.Infrastructure.Application.AutomaticDependencyInjection;
using Valenia.Infrastructure.Persistence;

namespace Valenia.Visas
{
    public class VisaRepository : RavenDbRepository<Visa, VisaId>, IVisaRepository, IScoped
    {
        public VisaRepository(IAsyncDocumentSession session)
            : base(session, id => $"Visa/{id.Value}") { }
    }
}
