namespace Encryptor.Domain.Entities;

public class MethodUsage
{
    public string MethodName { get; set; }
    public int AmountUsage { get; set; }
    public List<HistoryItem> History { get; set; }
}