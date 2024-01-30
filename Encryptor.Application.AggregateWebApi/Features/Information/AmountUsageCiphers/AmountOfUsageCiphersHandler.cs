using Encryptor.Application.Repositories;

namespace Encryptor.Application.AggregateWebApi.Features.Information.AmountUsageCiphers;

public class AmountOfUsageCiphersHandler(IAppDataRepository dataRepository)
{
    public async Task<IEnumerable<string>> Handle()
    {
        var task = Task.Run(dataRepository.GetFullInfo);

        var data = await task;

        return data.Select(kvp 
            => $"{kvp.Value.MethodName} was used {kvp.Value.AmountUsage} times");
    }
}