using Encryptor.Application.AggregateWebApi.Extension;
using Encryptor.Application.Repositories;

namespace Encryptor.Application.AggregateWebApi.Features.Encrypt;

public class EncryptService(IAppDataRepository appDataRepository, EncryptionMethodResolver methodResolver)
{
    private readonly IAppDataRepository _dataRepository = appDataRepository;

    public async Task<EncryptResponse> ExecuteEncryption(EncryptRequest req)
    {
        var cipher = methodResolver(req.CipherName);
        return new EncryptResponse(){OriginalText = cipher.MethodName};
    }
}