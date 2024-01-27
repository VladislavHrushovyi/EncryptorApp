using Encryptor.Application.AggregateWebApi.Features.Encrypt;
using Encryptor.Application.Repositories;
using Encryptor.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Encryptor.Application.AggregateWebApi.Extension;

public static class ServiceProvider
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddLoggers();
        services.AddEncryptionMethods();
        services.AddScoped<IAppDataRepository, AppDataRepository>();
        services.AddScoped<EncryptService>();
    }
}