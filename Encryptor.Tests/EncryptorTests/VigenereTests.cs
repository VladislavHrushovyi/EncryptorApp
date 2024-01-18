using Encryptor.Application.Features.Encryption.EncryptionMethods;
using Encryptor.Application.Features.Logger;

namespace Encryptor.Tests.EncryptorTests;

public class VigenereTests
{
    [Fact]
    public void CheckVigenereCipher__Test()
    {
        IEncryptor vigenereCipher = new VigenereEncryption(new List<IAppLogger>());

        var actualResult = vigenereCipher.Encrypt("Hello world!");
        var expectedResult = "Zincs pyvjv!";
        
        Assert.Equal(expectedResult, actualResult);
    }


    [Fact]
    public void CheckVigenereCipherLoggingToConsole()
    {
        IEnumerable<IAppLogger> _loggers = new List<IAppLogger>() { new ConsoleLogger()};
        IEncryptor vigenereCipher = new VigenereEncryption(_loggers);

        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        
        var actualResult = vigenereCipher.Encrypt("Hello world!");
        var expectedResult = "Zincs pyvjv!";
        
        Assert.Equal(expectedResult, actualResult);
        
        var consoleOutPut = stringWriter.ToString().Trim();
        var expectedOutputResult = "LOG: Vigenere cipher, original message: \'Hello world!\', encrypted text: \'Zincs pyvjv!\'";
        Assert.Equal(expectedOutputResult, consoleOutPut);
    }
    
    [Fact]
    public void CheckVigenereCipherLoggingToFile()
    {
        File.Delete("./Log.txt");
        IEnumerable<IAppLogger> _loggers = new List<IAppLogger>() { new FileLogger()};
        IEncryptor vigenereCipher = new VigenereEncryption(_loggers);

        var actualResult = vigenereCipher.Encrypt("Hello world!");
        var expectedResult = "Zincs pyvjv!";
        
        Assert.Equal(expectedResult, actualResult);
        
        var logLine = File.ReadLines("./Log.txt").First();
        var expectedLogLine = "Vigenere cipher, original message: \'Hello world!\', encrypted text: \'Zincs pyvjv!\'";
        
        Assert.Equal(expectedLogLine, logLine);
    }
    
    [Fact]
    public void CheckVigenereCipherLoggingToConsoleAndFile()
    {
        File.Delete("./Log.txt");
        IEnumerable<IAppLogger> _loggers = new List<IAppLogger>() { new FileLogger(), new ConsoleLogger()};
        IEncryptor vigenereCipher = new VigenereEncryption(_loggers);

        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        
        var actualResult = vigenereCipher.Encrypt("Hello world!");
        var expectedResult = "Zincs pyvjv!";
        
        Assert.Equal(expectedResult, actualResult);
        
        var consoleOutPut = stringWriter.ToString().Trim();
        var expectedOutputResult = "LOG: Vigenere cipher, original message: \'Hello world!\', encrypted text: \'Zincs pyvjv!\'";
        
        Assert.Equal(expectedOutputResult, consoleOutPut);
        
        var logLine = File.ReadLines("./Log.txt").First();
        var expectedLogLine = "Vigenere cipher, original message: \'Hello world!\', encrypted text: \'Zincs pyvjv!\'";
        
        Assert.Equal(expectedLogLine, logLine);
    }
}