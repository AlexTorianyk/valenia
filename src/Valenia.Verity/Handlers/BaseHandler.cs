using VeritySDK.Handler;
using VeritySDK.Protocols;

namespace Valenia.Verity.Handlers
{
    public abstract class BaseHandler
    {
        protected MessageFamily Handler { get; set; }
        protected MessageHandler.Handler MessageHandler { get; set; }
    }
}
