using Encryptor.Domain.Entities;

namespace Encryptor.Application.Repositories;

public interface IMethodInfoUsage
{
    public Dictionary<string, MethodUsage> GetFullInfo();
    public MethodUsage GetInfoByMethodName();
    public void AddMethodUsage();
    public void AddMessageInfo(string methodName, HistoryItem historyItem);

    public void SaveChanges();
}