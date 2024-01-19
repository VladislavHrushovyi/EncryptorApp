using System.Text;
using System.Text.Json;
using Encryptor.Domain.Entities;

namespace Encryptor.Infrastructure.Common.Utils;

public class AppDataSerialization
{
    private static readonly string _path = Environment.CurrentDirectory + @"\AppData.json";

    public static Dictionary<string, MethodUsage> ReadDataFromFile()
    {
        if (File.Exists(_path))
        {
            var file = File.ReadAllText(_path);
            var result = JsonSerializer.Deserialize<Dictionary<string, MethodUsage>>(file);

            return result;
        }

        return new Dictionary<string, MethodUsage>()
        {
            {
                "Xor", new MethodUsage()
                {
                    History = new List<HistoryItem>(),
                    AmountUsage = 0,
                    MethodName = "Xor"
                }
            },
            {
                "Caesar", new MethodUsage()
                {
                    History = new List<HistoryItem>(),
                    AmountUsage = 0,
                    MethodName = "Caesar"
                }
            },
            {
                "Vigenere", new MethodUsage()
                {
                    History = new List<HistoryItem>(),
                    AmountUsage = 0,
                    MethodName = "Vigenere"
                }
            }
        };
    }

    public static void Serialization(Dictionary<string, MethodUsage> usagesList)
    {
        FileStream stream;
        var json = JsonSerializer.Serialize(usagesList);
        
        if (!File.Exists(_path))
        { 
            stream = File.Create(_path);
            stream.Write(Encoding.Default.GetBytes(json));
            stream.Close();
            return;
        }
        stream = File.OpenWrite(_path);
        stream.Write(Encoding.Default.GetBytes(json));
        
        stream.Close();
    }
}