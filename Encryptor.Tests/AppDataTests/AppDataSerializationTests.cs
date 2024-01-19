using System.Globalization;
using System.Text.Json;
using Encryptor.Domain.Entities;
using Encryptor.Infrastructure.Common.Utils;

namespace Encryptor.Tests.AppDataTests;

public class AppDataSerializationTests
{
    private readonly Dictionary<string, MethodUsage> _methodUsages = InitFakeMethodUsages();

    private static Dictionary<string, MethodUsage> InitFakeMethodUsages()
    {
        return new Dictionary<string, MethodUsage>()
        {
            {
                "Xor", new MethodUsage()
                {
                    History = new List<HistoryItem>()
                    {
                        new HistoryItem()
                        {
                            AmountEncrypted = 2,
                            DateTime = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                            EncryptedMessage = "39 12 09 1E 1B 59 26 18 17 1E 10 58",
                            OriginalMessage = "Hello world!"
                        },
                        new HistoryItem()
                        {
                            AmountEncrypted = 1,
                            DateTime = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                            EncryptedMessage = "39 12 09 1E 1B 59 26 18 17 1E 10 58",
                            OriginalMessage = "Hello world!"
                        },
                    },
                    AmountUsage = 3,
                    MethodName = "Xor"
                }
            },
            {
                "Caesar", new MethodUsage()
                {
                    History = new List<HistoryItem>()
                    {
                        new HistoryItem()
                        {
                            AmountEncrypted = 2,
                            DateTime = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                            EncryptedMessage = "39 12 09 1E 1B 59 26 18 17 1E 10 58",
                            OriginalMessage = "Hello world!"
                        },
                        new HistoryItem()
                        {
                            AmountEncrypted = 2,
                            DateTime = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                            EncryptedMessage = "39 12 09 1E 1B 59 26 18 17 1E 10 58",
                            OriginalMessage = "Hello world!"
                        },
                    },
                    AmountUsage = 4,
                    MethodName = "Caesar"
                }
            },
            {
                "Vigenere", new MethodUsage()
                {
                    History = new List<HistoryItem>()
                    {
                        new HistoryItem()
                        {
                            AmountEncrypted = 2,
                            DateTime = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                            EncryptedMessage = "39 12 09 1E 1B 59 26 18 17 1E 10 58",
                            OriginalMessage = "Hello world!"
                        },
                        new HistoryItem()
                        {
                            AmountEncrypted = 3,
                            DateTime = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                            EncryptedMessage = "39 12 09 1E 1B 59 26 18 17 1E 10 58",
                            OriginalMessage = "Hello world!"
                        },
                    },
                    AmountUsage = 5,
                    MethodName = "Vigenere"
                }
            }
        };
    }

    [Fact]
    public void SerializationAppDataTest()
    {
        AppDataSerialization.Serialization(_methodUsages);

        var data = File.ReadAllText(Environment.CurrentDirectory + @"\AppData.json");
        var actualDict = JsonSerializer.Deserialize<Dictionary<string, MethodUsage>>(data);

        var expectedString = DictionaryToAssertableString(_methodUsages);
        var actualString = DictionaryToAssertableString(actualDict);
        
        Assert.Equal(expectedString, actualString);
    }

    private static string DictionaryToAssertableString(Dictionary<string, MethodUsage> dict)
    {
        var pairStrings = dict.OrderBy(d => d.Key)
            .Select(p => p.Key + ": " + DictValueToString(p.Value));

        return string.Join(", ", pairStrings);
    }

    private static string DictValueToString(MethodUsage methodUsage)
    {
        var historyString = methodUsage.History.Select(i => $"[{i.DateTime}, " +
                                                            $"{i.AmountEncrypted}, " +
                                                            $"{i.EncryptedMessage}, " +
                                                            $"{i.OriginalMessage}]");
        return $"{methodUsage.MethodName}, {methodUsage.AmountUsage}, {string.Join(", ", historyString)}";
    }
}