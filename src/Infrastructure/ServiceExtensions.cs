namespace Llano.Infrastructure;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Wolverine;

public static class ServiceExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddInfrastructure(IConfiguration configuration)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddWolverine(cfg =>
            {
                cfg.Discovery.IncludeAssembly(assembly);
            });

            return services;
        }
    }
}
