using Encryptor.Application.Repositories;

namespace Encryptor.Application.AggregateWebApi.Features.Information.InformationOfAllMessages;

public class InformationOfAllMessagesHandler(IAppDataRepository dataRepository)
{
    public async IAsyncEnumerable<string> Handle()
    {
        var data = await Task.Run(dataRepository.GetFullInfo);
        foreach (var methodUsage in data)
        {
            foreach (var historyItem in methodUsage.Value.History)
            {
                yield return $"{historyItem.DateTime} -" +
                                  $" Message \'{historyItem.OriginalMessage}\' was encrypted via " +
                                  $"{methodUsage.Value.MethodName} into \'{historyItem.EncryptedMessage}\'";
            }
        }
    }
}