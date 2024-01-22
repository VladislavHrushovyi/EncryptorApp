namespace Encryptor.Application.Common.Exception;

public class AppSettingDoesNotExist : System.Exception
{
    public AppSettingDoesNotExist(string message) : base(message)
    {
        
    }
}