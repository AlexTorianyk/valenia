using System.Collections.Generic;
using VeritySDK.Handler;
using VeritySDK.Protocols;
using VeritySDK.Protocols.IssueCredential;

namespace Valenia.Verity.Handlers
{
    public class IssueCredentialHandler
    {
        private MessageFamily _handler;
        private MessageHandler.Handler _messageHandler;

        public IssueCredentialHandler(string relationshipDID, string _defIdRef, Dictionary<string, string> credentialData, string credentialName)
        {
            _handler = IssueCredential.v1_0(relationshipDID, _defIdRef, credentialData, credentialName, "0", true);
            _messageHandler = (messageName, message) =>
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
