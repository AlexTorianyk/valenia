using VeritySDK.Handler;
using VeritySDK.Protocols;
using VeritySDK.Protocols.PresentProof;

namespace Valenia.Verity.Handlers
{
    public class RequestProofHandler
    {
        private MessageFamily _handler;
        private MessageHandler.Handler _messageHandler;

        public RequestProofHandler(string relationshipDID, string proofName, Attribute[] attributes)
        {
            _handler = PresentProof.v1_0(relationshipDID, proofName, attributes);
            _messageHandler = (messageName, message) =>
            {
                if ("presentation-result".Equals(messageName))
                {
                    var proofComplete = true;
                }
            };
        }
    }
}
