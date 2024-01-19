using Encryptor.Application.Repositories;
using Encryptor.Domain.Entities;
using Encryptor.Infrastructure.Common.Utils;

namespace Encryptor.Infrastructure.Repositories;

public class MethodInfoUsageRepository : IMethodInfoUsage
{
    private Dictionary<string, MethodUsage> _usagesList;

    public MethodInfoUsageRepository()
    {
        _usagesList = AppDataSerialization.ReadDataFromFile();
    }
    
    public Dictionary<string, MethodUsage> GetFullInfo()
    {
        throw new NotImplementedException();
    }

    public MethodUsage GetInfoByMethodName()
    {
        throw new NotImplementedException();
    }

    public void AddMethodUsage()
    {
        throw new NotImplementedException();
    }

    public void AddMessageInfo(string methodName, HistoryItem historyItem)
    {
        throw new NotImplementedException();
    }

    public void SaveChanges()
    {
        AppDataSerialization.Serialization(_usagesList);
    }
}