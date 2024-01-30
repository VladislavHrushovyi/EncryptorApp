using Encryptor.Application.Repositories;

namespace Encryptor.Application.AggregateWebApi.Features.Information.AmountUsageMessages;

public class AmountOfUsageMessagesHandler(IAppDataRepository dataRepository)
{
    public async IAsyncEnumerable<string> Handle()
    {
        var data = await Task.Run(dataRepository.GetFullInfo);
        foreach (var methodUsage in dataRepository.GetFullInfo())
        {
            foreach (var historyItem in methodUsage.Value.History)
            {
               yield return $"Message {historyItem.OriginalMessage} was encrypted via {methodUsage.Value.MethodName} {historyItem.AmountEncrypted} times";
            }
        }
    }
}