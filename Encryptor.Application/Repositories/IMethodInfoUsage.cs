using Encryptor.Domain.Entities;

namespace Encryptor.Application.Repositories;

public interface IMethodInfoUsage
{
    public IEnumerable<MethodUsage> GetFullInfo();
    public MethodUsage GetInfoByMethodName();
    public void AddMethodUsage();
    public void AddMessageInfo(string methodName, HistoryItem historyItem);
}