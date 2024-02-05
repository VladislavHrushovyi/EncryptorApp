using Encryptor.Application.AggregateWebApi.Features.Encrypt;
using Encryptor.Application.AggregateWebApi.Features.Information.AmountUsageCiphers;
using Encryptor.Application.AggregateWebApi.Features.Information.AmountUsageMessages;
using Encryptor.Application.AggregateWebApi.Features.Information.GetFullInfo;
using Encryptor.Application.AggregateWebApi.Features.Information.GetMethodUsageInfo;
using Encryptor.Application.AggregateWebApi.Features.Information.InformationOfAllMessages;
using Encryptor.Application.Repositories;
using Encryptor.Infrastructure.PostgreSql.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Encryptor.Application.AggregateWebApi.Extension;

public static class ServiceProvider
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddLoggers();
        services.AddEncryptionMethods();
        services.AddScoped<IAppDataRepository, MethodUsageRepository>();
        services.AddScoped<EncryptService>();
        services.AddScoped<GetFullInfoHandler>();
        services.AddScoped<GetMethodUsageInfoHandler>();
        services.AddScoped<AmountOfUsageCiphersHandler>();
        services.AddScoped<AmountOfUsageMessagesHandler>();
        services.AddScoped<InformationOfAllMessagesHandler>();
    }
}