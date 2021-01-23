using QRCoder;
using Valenia.Common;
using Valenia.Domain.TrustAnchors;
using Valenia.Verity.Relationships;
using VeritySDK.Handler;
using VeritySDK.Protocols;
using VeritySDK.Utils;
using Relationship = Valenia.Verity.Relationships.Relationship;

namespace Valenia.Verity.Handlers
{
    public class RelationshipHandler
    {
        private readonly IRelationshipRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private MessageFamily _handler { get; set; }
        private MessageHandler.Handler _messageHandler { get; set; }

        public RelationshipHandler(IRelationshipRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public virtual void SetUp(MessageFamily handler, string trustAnchorDID)
        {
            _handler = handler;
            _messageHandler = async (messageName, message) =>
            {
                if ("created".Equals(messageName))
                {
                    var threadId = message.GetValue("~thread")["thid"];
                    var relationshipDID = message.GetValue("did");

                    var relationship = new Relationship(relationshipDID.ToString(), threadId.ToString(), trustAnchorDID);
                    await _repository.Add(relationship);
                    await _unitOfWork.Commit();
                }
                else if ("invitation".Equals(messageName))
                {
                    var relationship =
                        await _repository.LoadByTrustAnchorDID(TrustAnchorDID.FromString(trustAnchorDID));
                    string inviteURL = message.GetValue("inviteURL");
                    relationship.SetInviteUrl(inviteURL);
                    await _unitOfWork.Commit();

                    var qrGenerator = new QRCodeGenerator();
                    var qrCodeData = qrGenerator.CreateQrCode(inviteURL, QRCodeGenerator.ECCLevel.L);
                    var qrCode = new QRCode(qrCodeData);
                    var qrCodeImage = qrCode.GetGraphic(4);
                    relationship.GenerateQrCode(qrCodeImage);
                    await _unitOfWork.Commit();
                }
            };
        }

    }
}
