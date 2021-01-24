using VeritySDK.Handler;
using VeritySDK.Protocols;
using VeritySDK.Protocols.Conecting;

namespace Valenia.Verity.Handlers
{
    public class ConnectionHandler
    {
        private MessageFamily _handler;
        private MessageHandler.Handler _messageHandler;

        public ConnectionHandler()
        {
            _handler = Connecting.v1_0("", "");
            _messageHandler = (messageName, message) =>
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
