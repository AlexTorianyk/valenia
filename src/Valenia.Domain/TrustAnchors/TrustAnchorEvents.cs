namespace Valenia.Domain.TrustAnchors
{
    public static class TrustAnchorEvents
    {
        public class Registered
        {
            public string DID { get; set; }
            public string VerKey { get; set; }
        }

        public class ConfigurationUpdated
        {
            public string Name { get; set; }
            public string Url { get; set; }
        }
    }
}
