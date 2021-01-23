using System.Threading.Tasks;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using Raven.Client.Documents.Linq;
using Valenia.Infrastructure.Application.AutomaticDependencyInjection;
using Valenia.Infrastructure.Persistence;

namespace Valenia.Verity.Relationships
{
    public class RelationshipRepository : RavenDbRepository<Relationship, RelationshipDID>, IRelationshipRepository, IScoped
    {
        public RelationshipRepository(IAsyncDocumentSession session) : base(session, id => $"Relationship/{id.Value}")
        {
        }

        public Task<Relationship> LoadByTrustAnchorDID(string trustAnchorDID)
        {
            return _session.Query<Relationship>().Where(x => x.TrustAnchorDID.Value == trustAnchorDID).SingleAsync();
        }
    }
}
