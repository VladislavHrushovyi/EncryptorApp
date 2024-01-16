﻿using System.Text;

namespace Encryptor.Application.Features.Encryption.EncryptionMethods;

public class XorEncryption : IEncryptor
{
    private readonly string _key = "qwerty";
    public string Encrypt(string originalText)
    {
        var currentKey = GetRepeatKey(originalText.Length);
        var sbResult = new StringBuilder();
        for (var i = 0; i < originalText.Length; i++)
        {
             sbResult.Append(((char)(originalText[i] ^ currentKey[i])));
        }

        return sbResult.ToString();
    }

    private string GetRepeatKey(int textLength)
    {
        var resKey = _key;
        while (resKey.Length < textLength)
        {
            resKey += resKey;
        }

        return resKey[..textLength];
    }
}