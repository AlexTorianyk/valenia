using System.Drawing;

namespace Valenia.Verity.Relationships
{
    public static class RelationshipEvents
    {
        public class Created
        {
            public string DID { get; set; }
            public string ThreadId { get; set; }
            public string TrustAnchorDID { get; set; }
        }

        public class InviteUrlChanged
        {
            public string InviteUrl { get; set; }
        }

        public class QrCodeGenerated
        {
            public Bitmap QrCode { get; set; } 
        }
    }
}
