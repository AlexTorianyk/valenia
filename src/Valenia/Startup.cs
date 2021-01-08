using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Raven.Client.Documents;
using Valenia.Infrastructure.Application;
using Valenia.Infrastructure.Application.AutomaticDependencyInjection;

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
            var store = new DocumentStore
            {
                Urls = new[] { "http://localhost:8080" },
                Database = "ValeniaDb",
                Conventions =
                {
                    FindIdentityProperty = x => x.Name == "DbId"
                }
            };
            services.AddScoped(c => store.OpenAsyncSession());
            store.Initialize();
            const string connectionString = "Server=localhost;Database=ValeniaDb;User Id=sa;Password=zaq1@WSX;";
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
