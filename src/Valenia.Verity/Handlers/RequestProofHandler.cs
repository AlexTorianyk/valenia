using VeritySDK.Protocols.PresentProof;
using Attribute = VeritySDK.Protocols.PresentProof.Attribute;

namespace Valenia.Verity.Handlers
{
    public class RequestProofHandler
    {
        public RequestProofHandler(string relationshipDID, string proofName, Attribute[] attributes)
        {
            Handler = PresentProof.v1_0(relationshipDID, proofName, attributes);
            MessageHandler = (messageName, message) =>
            {
                if ("presentation-result".Equals(messageName))
                {
                    var proofComplete = true;
                }
            };
        }

        protected override void SetUp()
        {
            throw new System.NotImplementedException();
        }
    }
}
