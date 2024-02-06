using System.Globalization;
using Encryptor.Domain.Entities;

namespace Encryptor.Infrastructure.PostgreSql.Entities.MapExtension;

public static class CipherToMethodUsage
{
    public static MethodUsage ToMethodUsage(this Ciphers cipher)
    {
        var result = new MethodUsage(){
            AmountUsage = cipher.AmountUsage,
            MethodName = cipher.Name,
            History = cipher.History.DistinctBy(x => x.OriginalText)
                .Select(historyItem => new HistoryItem()
                {
                    OriginalMessage = historyItem.OriginalText,
                    DateTime = cipher.History.OrderBy(x => x.CreatedAt)
                        .Last(x => x.CreatedAt == historyItem.CreatedAt)
                        .CreatedAt.ToString(CultureInfo.InvariantCulture),
                    EncryptedMessage = historyItem.EncryptedText,
                    AmountEncrypted = cipher.History.Count(x => x.OriginalText == historyItem.OriginalText &&
                                                                  x.CiphersId == cipher.Id)
                })
                .ToList()
        };
        
        return result;
    }
}