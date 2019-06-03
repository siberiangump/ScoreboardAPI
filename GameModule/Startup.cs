using Microsoft.Extensions.DependencyInjection;
using Scoreboard.Interfaces;

namespace RaceGameModule
{
    public class Startup : IGameModuleStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<Proxy.AccountProxy>();
            services.AddScoped<Proxy.TrackPregressProxy>();
        }

    }
}
