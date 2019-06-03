using Microsoft.Extensions.DependencyInjection;

namespace Scoreboard.Interfaces
{
    public interface IGameModuleStartup
    {
        void ConfigureServices(IServiceCollection services);
    }
}
