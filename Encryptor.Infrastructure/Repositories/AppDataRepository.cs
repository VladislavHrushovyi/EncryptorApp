using System.Globalization;
using Encryptor.Application.Repositories;
using Encryptor.Domain.Entities;
using Encryptor.Infrastructure.Common.Utils;

namespace Encryptor.Infrastructure.Repositories;

public class AppDataRepository : IAppDataRepository
{
    private readonly Dictionary<string, MethodUsage> _usagesList = AppDataSerialization.ReadDataFromFile();

    public Dictionary<string, MethodUsage> GetFullInfo()
    {
        return _usagesList;
    }

    public MethodUsage GetInfoByMethodName(string methodName)
    {
        if (string.IsNullOrWhiteSpace(methodName)) throw new ArgumentNullException();
        
        return _usagesList[methodName];
    }

    public void AddMessageInfo(string methodName, HistoryItem historyItem)
    {
        var methodUsage = _usagesList[methodName];
        methodUsage.AmountUsage += 1;
        if (methodUsage.History.Any(x => x.OriginalMessage == historyItem.OriginalMessage))
        {
            methodUsage.History = methodUsage.History.Select(x =>
            {
                if (x.OriginalMessage == historyItem.OriginalMessage)
                {
                    x.AmountEncrypted += 1;
                    x.DateTime = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                    return x;
                }

                return x;
            }).ToList();
        }
        else
        {
            methodUsage.History.Add(historyItem);
        }
        
    }

    public void SaveChanges()
    {
        AppDataSerialization.Serialization(_usagesList);
    }
}