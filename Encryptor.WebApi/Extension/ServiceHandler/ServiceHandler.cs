using Encryptor.Application.AggregateWebApi.Extension;

namespace Encryptor.WebApi.Extension.ServiceHandler;

public static class ServiceHandler
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddApplicationServices();
    }
}