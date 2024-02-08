using System.Reflection;

namespace Encryptor.Application.Common.Attributes;

public class ValueFromAttribute
{
    public static T GetValueFromAttribute<T>(object obj, string propertyName)
    {
        DefaultValue<T> attribute = (DefaultValue<T>)Attribute.GetCustomAttribute(
            obj.GetType().GetField(propertyName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance),
            typeof(DefaultValue<T>));
        return attribute.Value;
    }
    
    public static string GetValueFromAttribute(Type type, string propertyName)
    {
        var attribute = (DefaultValue<string>)type
            .GetField(propertyName)!
            .GetCustomAttribute(typeof(DefaultValue<string>));
        return attribute.Value;
    }
}