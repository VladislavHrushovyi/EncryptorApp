namespace Encryptor.Application.Features.Logger;

public class FileLogger : IAppLogger
{
    private readonly string _pathToLogFile = "./Log.txt";
    public void Log(string info)
    {
        var writer = File.AppendText(_pathToLogFile);
        writer.Write(info.AsEnumerable());
    }
}