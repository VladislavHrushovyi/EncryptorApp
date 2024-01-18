using Encryptor.Application.Features.Encryption.EncryptionMethods;
using Encryptor.Application.Features.Logger;

namespace Encryptor.Tests.EncryptorTests;

public class CaesarTests
{
    [Fact]
    public void CheckCaesarCipher()
    {
        IEncryptor caesar = new CaesarMethod(new List<IAppLogger>());

        var actualResult = caesar.Encrypt("hello caesar");
        var expectedResult = "khoor fdhvdu";
        
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void CheckCaesarCipherLogToConsole()
    {
        IEncryptor caesar = new CaesarMethod(new List<IAppLogger>(){new ConsoleLogger()});

        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        
        var actualResult = caesar.Encrypt("hello caesar");
        var expectedResult = "khoor fdhvdu";
        
        Assert.Equal(expectedResult, actualResult);

        var outFromConsole = stringWriter.ToString().Trim();
        var expectedOutFromConsole =
            "LOG: Caesar cipher, original message: \'hello caesar\', encrypted text: \'khoor fdhvdu\'";
        
        Assert.Equal(expectedOutFromConsole, outFromConsole);
    }
    
    [Fact]
    public void CheckCaesarCipherLogToFile()
    {
        File.Delete("./Log.txt");
        IEncryptor caesar = new CaesarMethod(new List<IAppLogger>(){new FileLogger()});

        var actualResult = caesar.Encrypt("hello caesar");
        var expectedResult = "khoor fdhvdu";
        
        Assert.Equal(expectedResult, actualResult);

        var actualLogLine = File.ReadLines("./Log.txt").First();
        var expectedLogLine = "Caesar cipher, original message: \'hello caesar\', encrypted text: \'khoor fdhvdu\'";
        
        Assert.Equal(expectedLogLine, actualLogLine);
    }
    
    [Fact]
    public void CheckCaesarCipherLogToConsoleAndFile()
    {
        File.Delete("./Log.txt");
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        
        IEncryptor caesar = new CaesarMethod(new List<IAppLogger>(){new ConsoleLogger(), new FileLogger()});

        var actualResult = caesar.Encrypt("hello caesar");
        var expectedResult = "khoor fdhvdu";
        
        Assert.Equal(expectedResult, actualResult);
        
        var actualLogLine = File.ReadLines("./Log.txt").First();
        var expectedLogLine = "Caesar cipher, original message: \'hello caesar\', encrypted text: \'khoor fdhvdu\'";
        
        Assert.Equal(expectedLogLine, actualLogLine);
        
        var outFromConsole = stringWriter.ToString().Trim();
        var expectedOutFromConsole =
            "LOG: Caesar cipher, original message: \'hello caesar\', encrypted text: \'khoor fdhvdu\'";
        
        Assert.Equal(expectedOutFromConsole, outFromConsole);
    }
}