namespace Llano.WebApi;

using Llano.Application;
using Llano.Infrastructure;

public static class Program
{
    public static async Task<int> Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.AddServiceDefaults();

        builder.Services.AddApplication();
        builder.Services.AddInfrastructure(builder.Configuration);

        builder.Services.AddControllers();
        builder.Services.AddOpenApi();

        var app = builder.Build();

        app.MapDefaultEndpoints();

        app.MapOpenApi();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/openapi/v1.json", "Llano API v1");
        });

        app.UseAuthorization();

        app.MapControllers();

        await app.RunAsync();

        return Environment.ExitCode;
    }
}
