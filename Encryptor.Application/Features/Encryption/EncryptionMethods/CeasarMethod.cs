using System.Text;
using Encryptor.Application.Common.Attributes;
using Encryptor.Application.Features.Logger;

namespace Encryptor.Application.Features.Encryption.EncryptionMethods;

public class CaesarMethod(IEnumerable<IAppLogger> _loggers) : IEncryptor
{
    [DefaultValue<int>("caesar.key")] // add name property from settings file
    private readonly int _key;

    private int Key => ValueFromAttribute.GetValueFromAttribute<int>(this, nameof(_key));

    public string MethodName { get; } = "Caesar";

    public string Encrypt(string originalText)
    {
        var sb = new StringBuilder();

        foreach (var symbol in originalText)
        {
            sb.Append(EncryptChar(symbol));
        }
        
        foreach (var logger in _loggers)
        {
            logger.Log($"Caesar cipher, original message: \'{originalText}\', encrypted text: \'{sb}\' \n");
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
        return (char)((((symbol + Key) - d) % 26) + d);  
    }
}