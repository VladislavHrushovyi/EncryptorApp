using Encryptor.Application.Repositories;
using Encryptor.Domain.Entities;

namespace Encryptor.Infrastructure.PostgreSql.Repositories;

public class MethodUsageRepository : IAppDataRepository
{
    public Dictionary<string, MethodUsage> GetFullInfo()
    {
        throw new NotImplementedException();
    }

    public MethodUsage GetInfoByMethodName(string methodName)
    {
        throw new NotImplementedException();
    }

    public void SaveChanges()
    {
        throw new NotImplementedException();
    }

    public void AddMessageInfo(string methodName, HistoryItem historyItem)
    {
        throw new NotImplementedException();
    }
}