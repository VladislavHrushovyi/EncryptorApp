using Encryptor.Application.Repositories;
using Encryptor.Domain.Entities;

namespace Encryptor.Infrastructure.Repositories;

public class MethodInfoUsageRepository : IMethodInfoUsage
{
    private List<Dictionary<string, MethodUsage>> _usagesList;

    public MethodInfoUsageRepository()
    {
        // read from file data of usage methods
    }
    
    public IEnumerable<MethodUsage> GetFullInfo()
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
}