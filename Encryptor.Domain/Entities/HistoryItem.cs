namespace Encryptor.Domain.Entities;

public class HistoryItem
{
    public string OriginalMessage { get; set; }
    public string EncryptedMessage { get; set; }
    public string DateTime { get; set; }
    public int AmountEncrypted { get; set; }
}