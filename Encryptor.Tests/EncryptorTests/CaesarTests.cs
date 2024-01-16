using Encryptor.Application.Features.Encryption.EncryptionMethods;

namespace Encryptor.Tests.EncryptorTests;

public class CaesarTests
{
    [Fact]
    public void CheckCaesarCipher()
    {
        IEncryptor caesar = new CaesarMethod();

        var actualResult = caesar.Encrypt("hello caesar");
        var expectedResult = "khoor fdhvdu";
        
        Assert.Equal(expectedResult, actualResult);
    }
}