using Encryptor.Application.AggregateWebApi.Extension;
using Encryptor.Application.Features.Encryption.EncryptionMethods;

namespace Encryptor.Application.AggregateWebApi.Features.Encrypt.MethodAggregators;

public class CaesarEncryptionAggregator(LoggerResolver loggerResolver)
{
    public IEncryptor Cipher { get; } = new CaesarMethod(loggerResolver("all"));
}