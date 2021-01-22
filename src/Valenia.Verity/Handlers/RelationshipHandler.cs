using System.Drawing.Imaging;
using System.IO;
using QRCoder;
using VeritySDK.Protocols.Relationship;
using VeritySDK.Utils;

namespace Valenia.Verity.Handlers
{
    public class RelationshipHandler : BaseHandler
    {
        public RelationshipHandler(string name = "Opole University of Technology")
        {
            Handler = Relationship.v1_0("relationship");
            MessageHandler = (messageName, message) =>
            {
                if ("created".Equals(messageName))
                {

                    var json_thread = message.GetValue("~thread")["thid"];

                    var threadId = json_thread;
                    var relDID = message.GetValue("did");

                }
                else if ("invitation".Equals(messageName))
                {
                    string inviteURL = message.GetValue("inviteURL");

                    try
                    {
                        var qrGenerator = new QRCodeGenerator();
                        var qrCodeData = qrGenerator.CreateQrCode(inviteURL, QRCodeGenerator.ECCLevel.L);
                        var qrCode = new QRCode(qrCodeData);
                        var qrCodeImage = qrCode.GetGraphic(4);
                        qrCodeImage.Save("qrcode.png", ImageFormat.Png);
                    }
                    catch (FileNotFoundException e)
                    {
                    }
                }
            };
        }
    }
}
