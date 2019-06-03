using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
// Scoreboard
using Scoreboard.Interfaces;
using Scoreboard.Services;

namespace Scoreboard
{
    public class Startup
    {
        readonly IGameModuleStartup GameModule = new RaceGameModule.Startup();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IMongoConnector, MongoConnector>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            GameModule.ConfigureServices(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
