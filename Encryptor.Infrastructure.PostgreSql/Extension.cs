using Encryptor.Application.Repositories;
using Encryptor.Infrastructure.PostgreSql.DataContext;
using Encryptor.Infrastructure.PostgreSql.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Encryptor.Infrastructure.PostgreSql;

public static class Extension
{
    public static void AddPostgreSql(this IServiceCollection services, IConfiguration config)
    {
        services.AddNpgsql<AppDataContext>(config["ConnectionString:EncryptorDb"]);
        services.AddScoped<AppDataContext>();
        services.AddScoped<IAppDataRepository, MethodUsageRepository>();
    }
}