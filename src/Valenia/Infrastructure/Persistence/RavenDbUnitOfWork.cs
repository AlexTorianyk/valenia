using System.Threading.Tasks;
using Raven.Client.Documents.Session;
using Valenia.Common;
using Valenia.Infrastructure.Application.AutomaticDependencyInjection;

namespace Valenia.Infrastructure.Persistence
{
    public class RavenDbUnitOfWork : IUnitOfWork, IScoped
    {
        private readonly IAsyncDocumentSession _session;

        public RavenDbUnitOfWork(IAsyncDocumentSession session)
            => _session = session;

        public Task Commit() => _session.SaveChangesAsync();
    }
}
