namespace Valenia.Verity.Context
{
    public static class ContextCommands
    {
        public class Provision
        {
            public string Token { get; set; }
            public string VerityApplicationEndpoint { get; set; }
            public string WalletId { get; set; }
            public string WalletKey { get; set; }
        }
    }
}
