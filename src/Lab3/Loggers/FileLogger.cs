namespace Itmo.ObjectOrientedProgramming.Lab3.Loggers;

public class FileLogger : ILogger
{
    public FileLogger(string path)
    {
        _path = path;
    }

    private readonly string _path;

    public void LogMessage(Message message)
    {
        File.AppendAllText(_path, $"{message.MessageText}\r\n");
    }
}