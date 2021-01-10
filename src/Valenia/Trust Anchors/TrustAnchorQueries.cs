using System.Linq;
using System.Threading.Tasks;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using Valenia.Domain.TrustAnchors;

namespace Valenia.Trust_Anchors
{
    public static class TrustAnchorQueries
    {
        public static Task<TrustAnchorReadModels.BrandInfo> Query(
            this IAsyncDocumentSession session,
            TrustAnchorQueryModels.GetBrandInfo query
        )
        {
            return session.Query<TrustAnchor>()
                .Where(x => x.Id.Value == query.DID)
                .Select(
                    x =>
                        new TrustAnchorReadModels.BrandInfo
                        {
                            Name = x.Name.Value,
                            LogoUrl = x.Logo.ToString()
                        }
                ).SingleAsync();
        }

        public static Task<TrustAnchorReadModels.VerityFields> Query(
            this IAsyncDocumentSession session,
            TrustAnchorQueryModels.GetVerityFieldsByName query
        )
        {
            return session.Query<TrustAnchor>()
                .Where(x => x.Name.Value == query.Name)
                .Select(
                    x =>
                        new TrustAnchorReadModels.VerityFields
                        {
                            DID = x.Id.Value,
                            VerKey = x.VerKey
                        }
                ).SingleAsync();
        }
    }
}
