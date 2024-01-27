using Encryptor.Application.AggregateWebApi.Extension;
using Encryptor.Application.Features.Encryption.EncryptionMethods;

namespace Encryptor.Application.AggregateWebApi.Features.Encrypt.MethodAggregators;

public class VigenereEncryptionAggregator(LoggerResolver loggerResolver)
{
    public IEncryptor Cipher { get; } = new VigenereEncryption(loggerResolver("all"));
}