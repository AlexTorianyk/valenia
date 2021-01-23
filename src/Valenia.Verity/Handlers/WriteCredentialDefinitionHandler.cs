using VeritySDK.Protocols.WriteCredDef;

namespace Valenia.Verity.Handlers
{
    public class WriteCredentialDefinitionHandler
    {
        public WriteCredentialDefinitionHandler(string credentialDefinitionName, string schemaIdReference, string credentialDefinitionTag)
        {
            Handler = WriteCredentialDefinition.v0_6(credentialDefinitionName, schemaIdReference, credentialDefinitionTag);
            MessageHandler = (messageName, message) =>
            {
                if ("status-report".Equals(messageName))
                {
                    var defIdRef = message["credDefId"];
                }
            };
        }

        protected override void SetUp()
        {
            throw new System.NotImplementedException();
        }
    }
}
