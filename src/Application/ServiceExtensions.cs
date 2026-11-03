namespace Llano.Application;

using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Wolverine;

public static class ServiceExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddApplication()
        {
            var applicationAssembly = Assembly.GetExecutingAssembly();

            services.AddWolverine(options =>
            {
                options.Discovery.IncludeAssembly(applicationAssembly);
            });

            return services;
        }
    }
}
