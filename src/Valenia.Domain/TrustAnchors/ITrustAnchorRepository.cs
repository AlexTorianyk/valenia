using System.Threading.Tasks;

namespace Valenia.Domain.TrustAnchors
{
    public interface ITrustAnchorRepository
    {
        Task<TrustAnchor> Load(TrustAnchorDID id);
        Task Add(TrustAnchor entity);
    }
}
