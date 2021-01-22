using System;
using System.Collections.Generic;
using System.Text;
using VeritySDK.Protocols.IssuerSetup;
using VeritySDK.Protocols.PresentProof;
using VeritySDK.Utils;
using Attribute = VeritySDK.Protocols.PresentProof.Attribute;

namespace Valenia.Verity.Handlers
{
    public class RequestProofHandler : BaseHandler
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
    }
}
