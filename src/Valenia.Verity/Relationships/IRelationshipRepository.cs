using System.Threading.Tasks;
using Valenia.Domain.TrustAnchors;

namespace Valenia.Verity.Relationships
{
    public interface IRelationshipRepository
    {
        Task<Relationship> Load(RelationshipDID did);
        Task Add(Relationship entity);
        Task<Relationship> LoadByTrustAnchorDID(TrustAnchorDID did);
    }
}
