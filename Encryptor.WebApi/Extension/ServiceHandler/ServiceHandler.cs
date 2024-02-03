using Encryptor.Application.AggregateWebApi.Extension;
using Encryptor.Infrastructure.PostgreSql;

namespace Encryptor.WebApi.Extension.ServiceHandler;

public static class ServiceHandler
{
    public static void AddServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddApplicationServices();
        services.AddPostgreSql(config);
    }
}