using System.Text;
using Encryptor.Application.Features.Encryption.EncryptionMethods;
using Encryptor.Application.Features.Logger;

namespace Encryptor.Tests.EncryptorTests;

public class XorTests
{
    [Fact]
    public void XorTestEncryptionText__test()
    {
        IEncryptor xorCipher = new XorEncryption(new List<IAppLogger>());

        var actualResult = xorCipher.Encrypt("Hello World!");
        var actualHexResult = BitConverter.ToString(Encoding.Default.GetBytes(actualResult)).Replace("-", " ");
        var expectedHexResult = "39 12 09 1E 1B 59 26 18 17 1E 10 58";
        
        Assert.Equal(expectedHexResult, actualHexResult);
    }

    [Fact]
    public void CheckXorCipherLoggingToConsole()
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        IEncryptor xorCipher = new XorEncryption(new List<IAppLogger>() {new ConsoleLogger()});

        var actualResult = xorCipher.Encrypt("Hello World!");
        var actualHexResult = BitConverter.ToString(Encoding.Default.GetBytes(actualResult)).Replace("-", " ");
        var expectedHexResult = "39 12 09 1E 1B 59 26 18 17 1E 10 58";
        
        Assert.Equal(expectedHexResult, actualHexResult);

        var actualConsoleOut = stringWriter.ToString().Trim();
        var expectedConsoleOut = $"LOG: Xor cipher, original message: \'Hello World!\', encrypted text: \'{actualResult}\'";
        
        Assert.Equal(expectedConsoleOut, actualConsoleOut);
    }
    
    [Fact]
    public void CheckXorCipherLoggingToFile()
    {
        File.Delete("./Log.txt");
        IEncryptor xorCipher = new XorEncryption(new List<IAppLogger>() { new FileLogger() });

        var actualResult = xorCipher.Encrypt("Hello World!");
        var actualHexResult = BitConverter.ToString(Encoding.Default.GetBytes(actualResult)).Replace("-", " ");
        var expectedHexResult = "39 12 09 1E 1B 59 26 18 17 1E 10 58";
        
        Assert.Equal(expectedHexResult, actualHexResult);

        var actualLogLine = File.ReadAllLines("./Log.txt").First();
        var expectedLogLine =
            $"Xor cipher, original message: \'Hello World!\', encrypted text: \'{actualResult}'";
        
        Assert.Equal(expectedLogLine, actualLogLine);
    }
    
    [Fact]
    public void CheckXorCipherLoggingToConsoleAndFile()
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        File.Delete("./Log.txt");
        
        IEncryptor xorCipher = new XorEncryption(new List<IAppLogger>() { new ConsoleLogger(), new FileLogger() });

        var actualResult = xorCipher.Encrypt("Hello World!");
        var actualHexResult = BitConverter.ToString(Encoding.Default.GetBytes(actualResult)).Replace("-", " ");
        var expectedHexResult = "39 12 09 1E 1B 59 26 18 17 1E 10 58";
        
        Assert.Equal(expectedHexResult, actualHexResult);
        
        var actualConsoleOut = stringWriter.ToString().Trim();
        var expectedConsoleOut = $"LOG: Xor cipher, original message: \'Hello World!\', encrypted text: \'{actualResult}\'";
        
        Assert.Equal(expectedConsoleOut, actualConsoleOut);
        
        var actualLogLine = File.ReadAllLines("./Log.txt").First();
        var expectedLogLine =
            $"Xor cipher, original message: \'Hello World!\', encrypted text: \'{actualResult}'";
        
        Assert.Equal(expectedLogLine, actualLogLine);
    }
}