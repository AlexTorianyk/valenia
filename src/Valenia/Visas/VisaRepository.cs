using System;
using System.Threading.Tasks;
using Valenia.Domain.Visas;
using Valenia.Infrastructure.Application.AutomaticDependencyInjection;
using Valenia.Infrastructure.Persistence;

namespace Valenia.Visas
{
    public class VisaRepository : IVisaRepository, IDisposable, IScoped
    {
        private readonly ValeniaDbContext _dbContext;

        public VisaRepository(ValeniaDbContext dbContext)
            => _dbContext = dbContext;

        public Task<Visa> Load(VisaId id)
            => _dbContext.Visas.FindAsync(id.Value).AsTask();

        public Task Add(Visa entity)
            => _dbContext.Visas.AddAsync(entity).AsTask();

        public async Task<bool> Exists(VisaId id)
            => await _dbContext.Visas.FindAsync(id.Value) != null;

        public void Dispose() => _dbContext.Dispose(); 
    }
}
