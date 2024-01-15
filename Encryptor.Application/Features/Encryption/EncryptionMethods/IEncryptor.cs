namespace Encryptor.Application.Features.Encryption.EncryptionMethods;

public interface IEncryptor
{
    public string Encrypt(string originalText);
}