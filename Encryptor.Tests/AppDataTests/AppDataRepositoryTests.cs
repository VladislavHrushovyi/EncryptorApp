using System.Globalization;
using Encryptor.Application.Features.Encryption.EncryptionMethods;
using Encryptor.Application.Features.Logger;
using Encryptor.Application.Repositories;
using Encryptor.Domain.Entities;
using Encryptor.Infrastructure.Repositories;

namespace Encryptor.Tests.AppDataTests;

public class AppDataRepositoryTests
{
    IEncryptor _vigenereCipher = new VigenereEncryption(new List<IAppLogger>(){new ConsoleLogger()});
    [Fact]
    public void AddHistoryItem()
    {
        File.Delete(Environment.CurrentDirectory + @"\AppData.json");
        IAppDataRepository appDataRepository = new AppDataRepositoryRepository();
        string originalMessage = "Hello World";
        HistoryItem historyItem = new HistoryItem()
        {
            DateTime = DateTime.Now.ToString(CultureInfo.InvariantCulture)
        };

        var encryptedText = _vigenereCipher.Encrypt(originalMessage);

        historyItem.EncryptedMessage = encryptedText;
        historyItem.OriginalMessage = originalMessage;
        historyItem.AmountEncrypted += 1;
        
        appDataRepository.AddMessageInfo("Vigenere", historyItem);
        var actualData = appDataRepository.GetInfoByMethodName("Vigenere");
        
        Assert.Equal(1, actualData.AmountUsage);
        Assert.Single(actualData.History);
        Assert.Equal(1, actualData.History.First().AmountEncrypted);
        Assert.Equal(originalMessage, actualData.History.First().OriginalMessage);
        Assert.Equal(encryptedText, actualData.History.First().EncryptedMessage);
        Assert.Equal(1, actualData.History.First().AmountEncrypted);
    }

    [Fact]
    public void AddMultipleSameHistoryItems()
    {
        File.Delete(Environment.CurrentDirectory + @"\AppData.json");
        IAppDataRepository appDataRepository = new AppDataRepositoryRepository();
        string originalMessage = "Hello World";
        HistoryItem historyItem = new HistoryItem()
        {
            DateTime = DateTime.Now.ToString(CultureInfo.InvariantCulture)
        };

        var encryptedText = _vigenereCipher.Encrypt(originalMessage);

        historyItem.EncryptedMessage = encryptedText;
        historyItem.OriginalMessage = originalMessage;
        historyItem.AmountEncrypted += 1;
        
        appDataRepository.AddMessageInfo("Vigenere", historyItem);
        appDataRepository.AddMessageInfo("Vigenere", historyItem);
        appDataRepository.AddMessageInfo("Vigenere", historyItem);
        appDataRepository.AddMessageInfo("Vigenere", historyItem);
        appDataRepository.AddMessageInfo("Vigenere", historyItem);
        var actualData = appDataRepository.GetInfoByMethodName("Vigenere");
        
        Assert.Equal(5, actualData.AmountUsage);
        Assert.Single(actualData.History);
        Assert.Equal(5, actualData.History.First().AmountEncrypted);
        Assert.Equal(originalMessage, actualData.History.First().OriginalMessage);
        Assert.Equal(encryptedText, actualData.History.First().EncryptedMessage);
    }

    [Fact]
    public void AddMultipleDifferentHistoryItems()
    {
        File.Delete(Environment.CurrentDirectory + @"\AppData.json");
        Dictionary<string, string> encryptes = new Dictionary<string, string>();
        IAppDataRepository appDataRepository = new AppDataRepositoryRepository();
        string originalMessage = "Hello World";
        for (int i = 0; i < 5; i++)
        {
            var origMessModif = $"{originalMessage}{i}";
            HistoryItem historyItem = new HistoryItem()
            {
                DateTime = DateTime.Now.ToString(CultureInfo.InvariantCulture)
            };

            var encryptedText = _vigenereCipher.Encrypt(origMessModif);

            historyItem.EncryptedMessage = encryptedText;
            historyItem.OriginalMessage = origMessModif;
            historyItem.AmountEncrypted += 1;
            appDataRepository.AddMessageInfo("Vigenere", historyItem);
            encryptes.Add(origMessModif, encryptedText);
        }
        
        var actualData = appDataRepository.GetInfoByMethodName("Vigenere");
        
        Assert.Equal(5, actualData.AmountUsage);
        Assert.Equal(5, actualData.History.Count);
        
        foreach (var encrypte in encryptes)
        {
            Assert.Contains(actualData.History, x => x.OriginalMessage == encrypte.Key);
            Assert.Contains(actualData.History, x => x.EncryptedMessage == encrypte.Value);
        }
    }
}