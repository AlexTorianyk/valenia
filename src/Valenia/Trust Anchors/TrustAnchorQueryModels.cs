namespace Valenia.Trust_Anchors
{
    public static class TrustAnchorQueryModels
    {
        public class GetBrandInfo
        {
            public string DID { get; set; }
        }

        public class GetVerityFieldsByName
        {
            public string Name { get; set; }
        }
    }
}
