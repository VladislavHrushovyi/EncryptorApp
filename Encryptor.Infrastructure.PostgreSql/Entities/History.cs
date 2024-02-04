namespace Encryptor.Infrastructure.PostgreSql.Entities;

public class History : BaseEntity
{
    public string OriginalText { get; set; }
    public string EncryptedText { get; set; }
    public DateTime CreatedAt { get; set; }
}