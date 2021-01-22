using System;
using System.IO;
using Valenia.Infrastructure.Application.AutomaticDependencyInjection;
using VeritySDK.Utils;

namespace Valenia.Verity.Context
{
    public class ContextRepository : IContextRepository, IScoped
    {
        private const string VERITY_CONTEXT_STORAGE = "verity-context.json";

        public Context Load()
        {
            try
            {
                var data = File.ReadAllText(VERITY_CONTEXT_STORAGE);

                var contextBuilder = ContextBuilder.fromJson(data);
                var context = contextBuilder.build();

                return new Context(context);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public void Add(Context entity)
        {
            File.WriteAllText(VERITY_CONTEXT_STORAGE, entity.VerityContext.toJson().ToString());
        }
    }
}
