using System.Data.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Valenia.Infrastructure.Application;
using Valenia.Infrastructure.Application.AutomaticDependencyInjection;
using Valenia.Infrastructure.Persistence;

namespace Valenia
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            const string connectionString = "Server=localhost;Database=ValeniaDb;User Id=sa;Password=zaq1@WSX;";
            services.AddDbContext<ValeniaDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<DbConnection>(c => new SqlConnection(connectionString));
            services.AddDependencies();
            services.AddControllers();
            services.AddSwagger();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
