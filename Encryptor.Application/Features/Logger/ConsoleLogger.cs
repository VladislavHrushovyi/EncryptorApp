namespace Encryptor.Application.Features.Logger;

public class ConsoleLogger : IAppLogger
{
    public void Log(string info)
    {
        Console.WriteLine($"LOG: {info}");
    }
}