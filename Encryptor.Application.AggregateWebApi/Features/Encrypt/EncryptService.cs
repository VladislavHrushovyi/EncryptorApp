using Encryptor.Application.Features.Encryption.EncryptionMethods;
using Encryptor.Application.Repositories;

namespace Encryptor.Application.AggregateWebApi.Features.Encrypt;

public class EncryptService(IAppDataRepository appDataRepository)
{
    private readonly IAppDataRepository _dataRepository = appDataRepository;

    public async Task<EncryptResponse> ExecuteEncryption(EncryptRequest req)
    {
        return new EncryptResponse();
    }
}