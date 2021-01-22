using VeritySDK.Protocols.Conecting;

namespace Valenia.Verity.Handlers
{
    public class ConnectionHandler : BaseHandler
    {
        public ConnectionHandler()
        {
            Handler = Connecting.v1_0("", "");
            MessageHandler = (messageName, message) =>
            {
                if ("request-received".Equals(messageName))
                {
                    var requestReceived = true;
                }
                else if ("response-sent".Equals(messageName))
                {
                    var startResponse = true;
                }
            };
        }
    }
}
