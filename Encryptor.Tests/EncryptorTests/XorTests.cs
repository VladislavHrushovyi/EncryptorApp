using System.Text;
using Encryptor.Application.Features.Encryption.EncryptionMethods;

namespace Encryptor.Tests.EncryptorTests;

public class XorTests
{
    [Fact]
    public void XorTestEncryptionText__test()
    {
        IEncryptor xorCipher = new XorEncryption();

        var actualResult = xorCipher.Encrypt("Hello World!");
        var actualHexResult = BitConverter.ToString(Encoding.Default.GetBytes(actualResult)).Replace("-", " ");
        var expectedHexResult = "39 12 09 1E 1B 59 26 18 17 1E 10 58";
        
        Assert.Equal(expectedHexResult, actualHexResult);
    }
}