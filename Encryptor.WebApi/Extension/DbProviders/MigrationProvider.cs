using Encryptor.Infrastructure.PostgreSql.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Encryptor.WebApi.Extension.DbProviders;

public static class MigrationProvider
{
    public static void MigrationDatabase(this WebApplication app)
    {
        var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetService<AppDataContext>();
        dbContext.Database.EnsureCreated();
    }
}