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
            var infrastructureAssembly = Assembly.GetExecutingAssembly();

            services.ConfigureWolverine(options =>
            {
                options.Discovery.IncludeAssembly(infrastructureAssembly);
            });

            return services;
        }
    }
}
