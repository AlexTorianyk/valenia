using VeritySDK.Handler;
using VeritySDK.Protocols;
using VeritySDK.Protocols.WriteSchema;

namespace Valenia.Verity.Handlers
{
    public class WriteSchemaHandler
    {
        private MessageFamily _handler;
        private MessageHandler.Handler _messageHandler;

        public WriteSchemaHandler(string schemaName, string schemaVersion, string[] parameters)
        {
            _handler = WriteSchema.v0_6(schemaName, schemaVersion, parameters);
            _messageHandler = (messageName, message) =>
            {
                if ("status-report".Equals(messageName))
                {
                    var schemaIdRef = message["schemaId"];
                }
            };
        }
    }
}
