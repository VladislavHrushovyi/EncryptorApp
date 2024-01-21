using System.Text;
using Encryptor.Application.Common.Attributes;
using Encryptor.Application.Features.Logger;

namespace Encryptor.Application.Features.Encryption.EncryptionMethods;

public class XorEncryption(IEnumerable<IAppLogger> _loggers) : IEncryptor
{
    [DefaultValue<string>("qwerty")]
    private readonly string _key = "qwerty";

    protected string Key => ValueFromAttribute.GetValueFromAttribute<string>(this, nameof(_key));
    public string Encrypt(string originalText)
    {
        var currentKey = GetRepeatKey(originalText.Length);
        var sbResult = new StringBuilder();
        for (var i = 0; i < originalText.Length; i++)
        {
             sbResult.Append(((char)(originalText[i] ^ currentKey[i])));
        }

        foreach (var logger in _loggers)
        {
            logger.Log($"Xor cipher, original message: \'{originalText}\', encrypted text: \'{sbResult}\'");
        }

        return sbResult.ToString();
    }

    private string GetRepeatKey(int textLength)
    {
        var resKey = Key;
        while (resKey.Length < textLength)
        {
            resKey += resKey;
        }

        return resKey[..textLength];
    }
}