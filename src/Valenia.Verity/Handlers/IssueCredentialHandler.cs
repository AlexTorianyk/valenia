using System.Collections.Generic;
using VeritySDK.Protocols.IssueCredential;

namespace Valenia.Verity.Handlers
{
    public class IssueCredentialHandler : BaseHandler
    {
        public IssueCredentialHandler(string relationshipDID, string _defIdRef, Dictionary<string, string> credentialData, string credentialName)
        {
            Handler = IssueCredential.v1_0(relationshipDID, _defIdRef, credentialData, credentialName, "0", true);
            MessageHandler = (messageName, message) =>
            {
                if ("sent".Equals(messageName))
                {
                    var offerSent = true;
                }
                else if ("sent".Equals(messageName))
                {
                    var credSent = true;
                }
            };
        }
    }
}
