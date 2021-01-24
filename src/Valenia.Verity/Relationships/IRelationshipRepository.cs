using System.Threading.Tasks;

namespace Valenia.Verity.Relationships
{
    public interface IRelationshipRepository
    {
        Task<Relationship> Load(RelationshipDID did);
        Task Add(Relationship entity);
        Task<Relationship> LoadByTrustAnchorDID(string did);
    }
}
