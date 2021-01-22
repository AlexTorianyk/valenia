using Valenia.Common;

namespace Valenia.Verity.Context
{
    public class Context : Value<Context>
    {
        public VeritySDK.Utils.Context VerityContext { get; private set; }

        public Context(VeritySDK.Utils.Context context)
        {
            VerityContext = context;
        }

        protected Context() { }
    }
}
