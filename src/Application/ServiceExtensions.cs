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
            var assembly = Assembly.GetExecutingAssembly();
            services.AddWolverine(opts =>
            {
                opts.Discovery.IncludeAssembly(assembly);
            });

            return services;
        }
    }
}
