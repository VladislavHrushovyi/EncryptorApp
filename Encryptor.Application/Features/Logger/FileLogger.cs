namespace Encryptor.Application.Features.Logger;

public class FileLogger : IAppLogger
{
    private readonly object lockObj = new();
    private readonly string _pathToLogFile = "./Log.txt";
    public void Log(string info)
    {
        lock (lockObj)
        {
            using var writer = File.AppendText(_pathToLogFile);
            writer.Write(info.AsEnumerable());   
        }
    }
}