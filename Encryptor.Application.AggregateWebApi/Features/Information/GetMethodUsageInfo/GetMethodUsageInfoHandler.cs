using Encryptor.Application.Repositories;
using Encryptor.Domain.Entities;

namespace Encryptor.Application.AggregateWebApi.Features.Information.GetMethodUsageInfo;

public class GetMethodUsageInfoHandler(IAppDataRepository dataRepository)
{
    public async Task<MethodUsage> Handle(string cipherName)
    {
        var task = Task.Run(() => dataRepository.GetInfoByMethodName(cipherName));
        var cipherData = await task;

        return cipherData;
    }
}