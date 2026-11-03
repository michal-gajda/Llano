# Llano

## Clean Architecture with WolverineFx

```powershell
dotnet new classlib --framework net10.0 --output src/Domain --name Llano.Domain
dotnet new classlib --framework net10.0 --output src/Application --name Llano.Application
dotnet new classlib --framework net10.0 --output src/Infrastructure --name Llano.Infrastructure
dotnet new webapi --framework net10.0 --no-https --use-controllers --use-program-main --output src/WebApi --name Llano.WebApi
```

```powershell
dotnet add src/Application reference src/Domain
dotnet add src/Infrastructure reference src/Application
dotnet add src/WebApi reference src/Infrastructure
```

```powershell
dotnet sln add src/WebApi
```

```powershell
dotnet add src/Application package WolverineFx
dotnet add src/Infrastructure package Microsoft.Extensions.Configuration.Binder
dotnet add src/WebApi package Swashbuckle.AspNetCore.SwaggerUI
```

```csharp
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

            services.AddWolverine(options =>
            {
                options.Discovery.IncludeAssembly(assembly);
            });

            return services;
        }
    }
}
```

```csharp
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

            services.AddWolverine(options =>
            {
                options.Discovery.IncludeAssembly(assembly);
            });

            return services;
        }
    }
}
```

## Functional Tests

```powershell
dotnet new nunit --framework net10.0 --output tests/FunctionalTests --name Llano.FunctionalTests
dotnet add tests/FunctionalTests reference src/Infrastructure
dotnet add tests/FunctionalTests package Microsoft.Extensions.Configuration
dotnet add tests/FunctionalTests package Microsoft.Extensions.DependencyInjection
dotnet add tests/FunctionalTests package Microsoft.Extensions.Logging
dotnet add tests/FunctionalTests package Shouldly
dotnet sln add tests/Application.FunctionalTests
```

## .NET Aspire

```powershell
dotnet new aspire-servicedefaults --framework net10.0 --output src/ServiceDefaults --name Llano.ServiceDefaults
dotnet add src/WebApi reference src/ServiceDefaults
dotnet sln add src/ServiceDefaults
```
