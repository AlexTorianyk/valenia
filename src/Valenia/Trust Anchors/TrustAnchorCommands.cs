namespace Valenia.Trust_Anchors
{
    public static class TrustAnchorCommands
    {
        public class Register
        {
        }
        
        public class UpdateConfiguration
        {
            public string DID { get; set; }
            public string Name { get; set; }
            public string LogoUrl { get; set; }
        }
    }
}
