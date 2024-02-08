using Encryptor.Application.AggregateWebApi.Features.Encrypt;
using Encryptor.Application.AggregateWebApi.Features.Information.AmountUsageCiphers;
using Encryptor.Application.AggregateWebApi.Features.Information.AmountUsageMessages;
using Encryptor.Application.AggregateWebApi.Features.Information.GetFullInfo;
using Encryptor.Application.AggregateWebApi.Features.Information.GetMethodUsageInfo;
using Encryptor.Application.AggregateWebApi.Features.Information.InformationOfAllMessages;
using Encryptor.Application.Common.Attributes;
using Encryptor.Application.Repositories;
using Encryptor.Infrastructure.PostgreSql.Repositories;
using Encryptor.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Encryptor.Application.AggregateWebApi.Extension;

public static class ServiceProvider
{
    [DefaultValue<string>("type_storage")] 
    public static readonly string TypeStorage = "default";
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddLoggers();
        services.AddEncryptionMethods();
        HandleStorage(services);
        services.AddScoped<EncryptService>();
        services.AddScoped<GetFullInfoHandler>();
        services.AddScoped<GetMethodUsageInfoHandler>();
        services.AddScoped<AmountOfUsageCiphersHandler>();
        services.AddScoped<AmountOfUsageMessagesHandler>();
        services.AddScoped<InformationOfAllMessagesHandler>();
    }

    private static void HandleStorage(IServiceCollection serviceCollection)
    {
        var attributeValue = ValueFromAttribute.GetValueFromAttribute(typeof(ServiceProvider), nameof(TypeStorage));
        if (string.IsNullOrEmpty(attributeValue))
        {
            serviceCollection.AddScoped<IAppDataRepository, MethodUsageRepository>();
        }
        else
        {
            switch (attributeValue)
            {
                case "local":
                    serviceCollection.AddScoped<IAppDataRepository, AppDataRepository>();
                    break;
                case "database":
                    serviceCollection.AddScoped<IAppDataRepository, MethodUsageRepository>();
                    break;
                default:
                    throw new Exception($"Unresolved type of storage {attributeValue}");
            }
        }
    }
}