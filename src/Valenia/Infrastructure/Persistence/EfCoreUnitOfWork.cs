using System.Threading.Tasks;
using Valenia.Common;
using Valenia.Infrastructure.Application.AutomaticDependencyInjection;

namespace Valenia.Infrastructure.Persistence
{
    public class EfCoreUnitOfWork : IUnitOfWork, IScoped
    {
        private readonly ValeniaDbContext _dbContext;

        public EfCoreUnitOfWork(ValeniaDbContext dbContext)
            => _dbContext = dbContext;

        public Task Commit() => _dbContext.SaveChangesAsync();
    }
}
