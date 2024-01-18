﻿using System.Text;
using Encryptor.Application.Features.Logger;

namespace Encryptor.Application.Features.Encryption.EncryptionMethods;

public class VigenereEncryption(IEnumerable<IAppLogger> loggers) : IEncryptor
{
    private readonly string _secretKey = "secretkey";

    public string Encrypt(string originalText)
    {
        var gamma = GetRepeatKey(originalText.Length);
        var sbResult = new StringBuilder();
        var alphabetSize = 26;
        int gammaIndex = 0;
        foreach (var letter in originalText)
        {
            if (!char.IsLetter(letter))
            {
                sbResult.Append(letter);
            }
            else
            {
                var d = char.IsUpper(letter) ? 'A' : 'a';
                var letterCode = letter - d;
                var gammaCode = char.IsUpper(letter) ? 
                    char.ToUpper(gamma[gammaIndex]) - d
                    : gamma[gammaIndex] - d;
                
                var encryptedLetterCode = (letterCode + gammaCode) % alphabetSize;

                sbResult.Append((char)(encryptedLetterCode + d));
                gammaIndex++;
            }
        }

        foreach (var logger in loggers)
        {
            logger.Log($"Vigenere cipher, original message: \'{originalText}\', encrypted text: \'{sbResult}\'");
        }
        return sbResult.ToString();
    }
    
    private string GetRepeatKey(int originalTextLength)
    {
        var key = _secretKey;
        var repeatedKey = new StringBuilder(originalTextLength);

        for (int i = 0; i < originalTextLength; i++)
        {
            repeatedKey.Append(key[i % key.Length]);
        }

        return repeatedKey.ToString();
    }
}