using Encryptor.Application.AggregateWebApi.Extension;
using Encryptor.Application.Features.Encryption.EncryptionMethods;

namespace Encryptor.Application.AggregateWebApi.Features.Encrypt.MethodAggregators;

public class XorEncryptionAggregator(LoggerResolver loggerResolver)
{
    public IEncryptor Cipher = new XorEncryption(loggerResolver("all"));
}