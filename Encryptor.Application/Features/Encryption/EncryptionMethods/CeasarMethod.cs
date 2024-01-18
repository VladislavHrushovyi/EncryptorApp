using System.Text;
using Encryptor.Application.Features.Logger;

namespace Encryptor.Application.Features.Encryption.EncryptionMethods;

public class CaesarMethod(IEnumerable<IAppLogger> _loggers) : IEncryptor
{
    private readonly int _key = 3;
    
    public string Encrypt(string originalText)
    {
        var sb = new StringBuilder();

        foreach (var symbol in originalText)
        {
            sb.Append(EncryptChar(symbol));
        }
        
        foreach (var logger in _loggers)
        {
            logger.Log($"Caesar cipher, original message: \'{originalText}\', encrypted text: \'{sb}\'");
        }
        return sb.ToString();
    }

    private char EncryptChar(char symbol)
    {
        if (!char.IsLetter(symbol))
        {
            return symbol;
        }
        
        char d = char.IsUpper(symbol) ? 'A' : 'a';  
        return (char)((((symbol + _key) - d) % 26) + d);  
    }
}