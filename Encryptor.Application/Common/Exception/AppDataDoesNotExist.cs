namespace Encryptor.Application.Common.Exception;

public class AppDataDoesNotExist : System.Exception
{
    public AppDataDoesNotExist(string message) : base(message)
    {
        
    }
}