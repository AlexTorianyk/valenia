using VeritySDK.Protocols.IssuerSetup;
using VeritySDK.Utils;

namespace Valenia.Verity.Handlers
{
    public class IssuerSetupHandler : BaseHandler
    {
        public IssuerSetupHandler()
        {
            Handler = IssuerSetup.v0_6();
            MessageHandler = (messageName, message) =>
            {
                if ("public-identifier-created".Equals(messageName))
                {
                    var json_identifier = message.GetValue("identifier");
                    var issuerDID = json_identifier["did"];
                    var issuerVerKey = json_identifier["verKey"];
                }
            };
        }
    }
}
