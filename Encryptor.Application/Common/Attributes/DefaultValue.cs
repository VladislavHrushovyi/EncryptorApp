namespace Encryptor.Application.Common.Attributes;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class DefaultValue<T>(string key) : Attribute
{
    public readonly T? Value = (T)Convert.ChangeType(key, typeof(T));
}