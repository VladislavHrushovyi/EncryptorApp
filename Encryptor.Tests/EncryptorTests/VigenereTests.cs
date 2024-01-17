using Encryptor.Application.Features.Encryption.EncryptionMethods;

namespace Encryptor.Tests.EncryptorTests;

public class VigenereTests
{
    [Fact]
    public void CheckVigenereCipher__Test()
    {
        IEncryptor vigenereCipher = new VigenereEncryption();

        var actualResult = vigenereCipher.Encrypt("Hello world!");
        var expectedResult = "Zincs pyvjv!";
        
        Assert.Equal(expectedResult, actualResult);
    }
}