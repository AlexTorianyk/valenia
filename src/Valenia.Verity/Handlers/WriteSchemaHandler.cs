using VeritySDK.Protocols.WriteSchema;

namespace Valenia.Verity.Handlers
{
    public class WriteSchemaHandler : BaseHandler
    {
        public WriteSchemaHandler(string schemaName, string schemaVersion, string[] parameters)
        {
            Handler = WriteSchema.v0_6(schemaName, schemaVersion, parameters);
            MessageHandler = (messageName, message) =>
            {
                if ("status-report".Equals(messageName))
                {
                    var schemaIdRef = message["schemaId"];
                }
            };
        }
    }
}
