namespace Valenia.Trust_Anchors
{
    public static class TrustAnchorReadModels
    {
        public class BrandInfo
        {
            public string Name { get; set; }
            public string LogoUrl { get; set; }
        }

        public class VerityFields
        {
            public string DID { get; set; }
            public string VerKey { get; set; }
        }
    }
}
