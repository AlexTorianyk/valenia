using Microsoft.Extensions.DependencyInjection;
using Valenia.Verity.Contexts;

namespace Valenia.Infrastructure.Verity
{
    public static class ContextExtension
    {
        public static void AddContext(this IServiceCollection services)
        {
            var contextRepository = new ContextRepository();
            var context = contextRepository.Load();
            services.AddSingleton(c => context);
        }
    }
}
