using System;
using System.Drawing;
using Valenia.Common;
using Valenia.Domain.Shared.Exceptions;
using Valenia.Domain.TrustAnchors;

namespace Valenia.Verity.Relationships
{
    public class Relationship : AggregateRoot<RelationshipDID>
    {
        public string ThreadId { get; set; }
        public TrustAnchorDID TrustAnchorDID { get; set; }
        public Bitmap QrCode { get; set; }
        public Uri InviteUrl { get; set; }

        public Relationship(string relationshipDID, string threadId, string trustAnchorDID)
        {
            Apply(new RelationshipEvents.Created
            {
                DID = relationshipDID,
                ThreadId = threadId,
                TrustAnchorDID = trustAnchorDID
            });
        }

        public void SetInviteUrl(string inviteUrl)
        {
            Apply(new RelationshipEvents.InviteUrlChanged
            {
                InviteUrl = inviteUrl,
            });
        }

        public void GenerateQrCode(Bitmap qrCode)
        {
            Apply(new RelationshipEvents.QrCodeGenerated
            {
                QrCode = qrCode
            });
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case RelationshipEvents.Created e:
                    Id = new RelationshipDID(e.DID);
                    ThreadId = e.ThreadId;
                    TrustAnchorDID = new TrustAnchorDID(e.TrustAnchorDID);
                    break;
                case RelationshipEvents.InviteUrlChanged e:
                    InviteUrl = new Uri(e.InviteUrl);
                    break;
                case RelationshipEvents.QrCodeGenerated e:
                    QrCode = e.QrCode;
                    break;
            }
        }

        protected override void EnsureValidState()
        {
            if (Id is null)
                throw new Exceptions.InvalidEntityState(this,
                    $"Post-checks failed for Relationship {Id}");
        }

        private string DbId
        {
            get => $"Relationship/{Id.Value}";
            set { }
        }

        protected Relationship() { }
    }
}
