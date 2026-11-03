namespace Llano.FunctionalTests;

using Llano.Application;
using Llano.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public abstract class TestBase
{
    private IHost? host;

    protected IServiceProvider ServiceProvider =>
        this.host?.Services ?? throw new InvalidOperationException("The test host has not started.");

    [OneTimeSetUp]
    public async Task StartHost()
    {
        var collection = new Dictionary<string, string?>
        {
            { "ConnectionStrings:DefaultConnection", "Server=localhost;Database=llano;User Id=sa;******" }
        };

        this.host = await Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((_, configuration) =>
            {
                configuration.AddInMemoryCollection(collection);
                configuration.AddEnvironmentVariables();
            })
            .ConfigureServices((context, services) =>
            {
                services.AddApplication();
                services.AddInfrastructure(context.Configuration);
            })
            .StartAsync();
    }

    [OneTimeTearDown]
    public async Task StopHost()
    {
        if (this.host is null)
        {
            return;
        }

        await this.host.StopAsync();
        await ((IAsyncDisposable)this.host).DisposeAsync();
    }
}
