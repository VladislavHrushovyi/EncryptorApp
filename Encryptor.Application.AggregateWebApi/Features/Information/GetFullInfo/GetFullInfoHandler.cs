using Encryptor.Application.Repositories;
using Encryptor.Domain.Entities;

namespace Encryptor.Application.AggregateWebApi.Features.Information.GetFullInfo;

public class GetFullInfoHandler(IAppDataRepository dataRepository)
{
    public IEnumerable<MethodUsage> Handle()
    {
        return dataRepository.GetFullInfo().Select(kvp => kvp.Value);
    }
}