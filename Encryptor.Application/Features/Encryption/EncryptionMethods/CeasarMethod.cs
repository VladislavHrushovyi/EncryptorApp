using System.Text;

namespace Encryptor.Application.Features.Encryption.EncryptionMethods;

public class CaesarMethod : IEncryptor
{
    private readonly int _key = 3;
    public string Encrypt(string originalText)
    {
        var sb = new StringBuilder();

        foreach (var symbol in originalText)
        {
            sb.Append(EncryptChar(symbol));
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