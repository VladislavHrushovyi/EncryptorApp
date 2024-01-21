using System.ComponentModel;

namespace Encryptor.ConsoleApp;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class TestAttribute(string value) : Attribute
{
    public string Name { get; } = value;
}