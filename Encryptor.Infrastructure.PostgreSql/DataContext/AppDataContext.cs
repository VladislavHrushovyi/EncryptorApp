using Encryptor.Infrastructure.PostgreSql.Entities;
using Microsoft.EntityFrameworkCore;

namespace Encryptor.Infrastructure.PostgreSql.DataContext;

public class AppDataContext : DbContext
{
    public DbSet<Ciphers> Ciphers { get; set; }
    public DbSet<History> History { get; set; }

    public AppDataContext(DbContextOptions<AppDataContext> contextOptions) : base(contextOptions)
    {
        
    }
}