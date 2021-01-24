using VeritySDK.Handler;
using VeritySDK.Protocols;
using VeritySDK.Protocols.WriteCredDef;

namespace Valenia.Verity.Handlers
{
    public class WriteCredentialDefinitionHandler
    {
        private MessageFamily _handler;
        private MessageHandler.Handler _messageHandler;

        public WriteCredentialDefinitionHandler(string credentialDefinitionName, string schemaIdReference, string credentialDefinitionTag)
        {
            _handler = WriteCredentialDefinition.v0_6(credentialDefinitionName, schemaIdReference, credentialDefinitionTag);
            _messageHandler = (messageName, message) =>
            {
                if ("status-report".Equals(messageName))
                {
                    var defIdRef = message["credDefId"];
                }
            };
        }
    }
}
