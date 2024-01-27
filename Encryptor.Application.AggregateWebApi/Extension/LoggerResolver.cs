using Encryptor.Application.Features.Logger;
using Microsoft.Extensions.DependencyInjection;

namespace Encryptor.Application.AggregateWebApi.Extension;

public delegate IEnumerable<IAppLogger> LoggerResolver(string key);

public static class LoggerServiceResolver
{
    public static void AddLoggers(this IServiceCollection services)
    {
        services.AddScoped<ConsoleLogger>();
        services.AddScoped<FileLogger>();
        services.AddScoped<LoggerResolver>(serviceProvider => key =>
        {
            return key switch
            {
                "console" => new List<IAppLogger>()
                {
                    serviceProvider.GetService<ConsoleLogger>()!
                },
                "file" => new List<IAppLogger>()
                {
                    serviceProvider.GetService<FileLogger>()!
                },
                "all" => new List<IAppLogger>()
                {
                    serviceProvider.GetService<ConsoleLogger>()!,
                    serviceProvider.GetService<FileLogger>()!
                    
                },
                _ => throw new ArgumentOutOfRangeException(nameof(key), key, null)
            };
        });
    }
}