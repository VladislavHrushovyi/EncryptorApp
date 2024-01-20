using Encryptor.Domain.Entities;

namespace Encryptor.Application.Repositories;

public interface IAppDataRepository
{
    public Dictionary<string, MethodUsage> GetFullInfo();
    public MethodUsage GetInfoByMethodName(string methodName);
    public void AddMessageInfo(string methodName, HistoryItem historyItem);

    public void SaveChanges();
}