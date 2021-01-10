using Raven.Client.Documents.Session;
using Valenia.Domain.TrustAnchors;
using Valenia.Infrastructure.Application.AutomaticDependencyInjection;
using Valenia.Infrastructure.Persistence;

namespace Valenia.Trust_Anchors
{
    public class TrustAnchorRepository : RavenDbRepository<TrustAnchor, TrustAnchorDID>, ITrustAnchorRepository, IScoped
    {
        public TrustAnchorRepository(IAsyncDocumentSession session)
            : base(session, id => $"TrustAnchor/{id.Value}")
        {
        }
    }
}
