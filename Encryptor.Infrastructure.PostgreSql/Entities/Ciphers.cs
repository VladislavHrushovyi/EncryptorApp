namespace Encryptor.Infrastructure.PostgreSql.Entities;

public class Ciphers : BaseEntity
{
    public string Name { get; set; }
    public int AmountUsage { get; set; }
    public virtual ICollection<History> History { get; set; }
    public DateTime UpdateAt { get; set; }
}