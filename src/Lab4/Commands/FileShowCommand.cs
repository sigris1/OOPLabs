using Itmo.ObjectOrientedProgramming.Lab4.Systems;
using Itmo.ObjectOrientedProgramming.Lab4.Viewers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileShowCommand : ICommand
{
    private readonly string _path;
    private readonly string _mode;

    private IViewer GetViewer()
    {
        if (_mode == "console")
        {
            return new ConsoleViewer();
        }

        return new FileViewer("fileViewer.txt");
    }

    public FileShowCommand(string path, string mode)
    {
        _path = path;
        _mode = mode;
    }

    public void DoCommand(ISystem system)
    {
        IViewer viewer = GetViewer();
        system.FileShow(_path, viewer);
    }

    public bool Equals(ICommand? other)
    {
        if (other is not FileShowCommand)
        {
            return false;
        }

        if (other is FileShowCommand fileShowCommand)
        {
            return _path == fileShowCommand._path && _mode == fileShowCommand._mode;
        }

        return false;
    }
}