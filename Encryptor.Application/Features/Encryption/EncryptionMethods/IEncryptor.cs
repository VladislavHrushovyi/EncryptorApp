namespace Encryptor.Application.Features.Encryption.EncryptionMethods;

public interface IEncryptor
{
    public string MethodName { get; }
    public string Encrypt(string originalText);
}