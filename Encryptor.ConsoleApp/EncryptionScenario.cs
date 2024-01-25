using System.Globalization;
using Encryptor.Application.Features.Encryption.EncryptionMethods;
using Encryptor.Application.Features.Logger;
using Encryptor.Application.Repositories;
using Encryptor.Domain.Entities;

namespace Encryptor.ConsoleApp;

public class EncryptionScenario(IAppDataRepository dataRepository, List<IAppLogger> loggers)
{
    public void StartScenario()
    {
        bool isBack = false;
        
        IEncryptor encryptionCipher;
        while (!isBack)
        {
            ShowNavigation();
            Console.WriteLine("Choose item from 1 to 4:");
            switch (Console.ReadLine())
            {
                case "1":
                    encryptionCipher = new CaesarMethod(loggers);
                    DoEncryption(encryptionCipher);
                    break;
                case "2":
                    encryptionCipher = new VigenereEncryption(loggers);
                    DoEncryption(encryptionCipher);
                    break;
                case "3":
                    encryptionCipher = new XorEncryption(loggers);
                    DoEncryption(encryptionCipher);
                    break;
                case "4":
                    isBack = true;
                    break;
            }
        }
    }

    private void DoEncryption(IEncryptor encryptionCipher)
    {
        Console.WriteLine("Enter the text:");
        string text = Console.ReadLine() ?? throw new ArgumentException("Text for encryption must be not empty");

        var result = encryptionCipher.Encrypt(text);
        var historyItem = new HistoryItem()
        {
            AmountEncrypted = 1,
            DateTime = DateTime.Now.ToString(CultureInfo.InvariantCulture),
            OriginalMessage = text,
            EncryptedMessage = result
        };
        dataRepository.AddMessageInfo(encryptionCipher.MethodName, historyItem);
        
        Console.WriteLine("PRESS ANY BUTTON TO CONTINUE");
        Console.ReadKey();
    }

    private void ShowNavigation()
    {
        Console.Clear();
        Console.WriteLine("**********Encryption-MENU*********");
        Console.WriteLine("1. Caesar cipher");
        Console.WriteLine("2. Vigenere cipher");
        Console.WriteLine("3. Xor cipher");
        Console.WriteLine("4. To main menu");
        Console.WriteLine("*************END-MENU*************");
    }
}