using Encryptor.Application.Common.Exception;

namespace Encryptor.Application.Common.Attributes;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class DefaultValue<T>(string key) : Attribute
{
    private static readonly Dictionary<string, string> appValues = new();

    static DefaultValue()
    {
        if (!File.Exists("D:\\Project\\Encryptor\\Encryptor.Application\\ApplicationSettings.txt"))
            throw new AppSettingDoesNotExist("ApplicationSettings.txt not found");
        
        var settingsString =
            File.ReadAllLines("D:\\Project\\Encryptor\\Encryptor.Application\\ApplicationSettings.txt");

        foreach (var setting in settingsString)
        {
            var splitSetting = setting.Trim().Split("=");
            appValues.Add(splitSetting[0], splitSetting[1]);
        }
    }
    
    public readonly T? Value = (T)Convert.ChangeType(GetValueByKey(key), typeof(T));

    private static string GetValueByKey(string key)
    {
        if (!appValues.ContainsKey(key)) 
            throw new AppSettingDoesNotExist($"Key {key} not provided in ApplicationSettings.txt");
        return appValues[key];
    }
}