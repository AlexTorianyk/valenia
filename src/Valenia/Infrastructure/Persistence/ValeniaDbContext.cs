using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;
using Valenia.Domain.Visas;
using Valenia.Domain.Visas.Requirements;

namespace Valenia.Infrastructure.Persistence
{
    public class ValeniaDbContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;

        public ValeniaDbContext(
            DbContextOptions<ValeniaDbContext> options,
            ILoggerFactory loggerFactory)
            : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        public DbSet<Visa> Visas { get; set; }
        public DbSet<Requirement> Requirements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VisaEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RequirementEntityTypeConfiguration());
        }
    }

    public class VisaEntityTypeConfiguration : IEntityTypeConfiguration<Visa>
    {
        public void Configure(EntityTypeBuilder<Visa> builder)
        {
            builder.HasKey(x => x.VisaId);
            builder.OwnsOne(x => x.Id);
            builder.OwnsOne(x => x.Goal);
            builder.OwnsOne(x => x.ExpectedProcessingTime);
        }
    }

    public class RequirementEntityTypeConfiguration : IEntityTypeConfiguration<Requirement>
    {
        public void Configure(EntityTypeBuilder<Requirement> builder)
        {
            builder.HasKey(x => x.RequirementId);
            builder.OwnsOne(x => x.Id);
            builder.OwnsOne(x => x.ParentId);
            builder.OwnsOne(x => x.Name);
            builder.OwnsOne(x => x.Description);
            builder.OwnsOne(x => x.Example);
        }
    }
}