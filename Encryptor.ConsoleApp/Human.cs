using System.ComponentModel;

namespace Encryptor.ConsoleApp;

public class Human
{
    [Test("Joerge")]
    private string _name;

    public string Name
    {
        get
        {
            TestAttribute attribute = (TestAttribute)Attribute.GetCustomAttribute(
                GetType().GetField("_name", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance),
                typeof(TestAttribute));
            return attribute.Name;
        }
    }

    public void ShowName()
    {
        Console.WriteLine(Name);
    }
}