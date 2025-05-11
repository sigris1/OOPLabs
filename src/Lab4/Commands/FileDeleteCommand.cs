using Itmo.ObjectOrientedProgramming.Lab4.Systems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileDeleteCommand : ICommand
{
    private readonly string _path;

    public FileDeleteCommand(string path)
    {
        _path = path;
    }

    public void DoCommand(ISystem system)
    {
        system.FileDelete(_path);
    }

    public bool Equals(ICommand? other)
    {
        if (other is not FileDeleteCommand)
        {
            return false;
        }

        if (other is FileDeleteCommand fileDeleteCommand)
        {
            return _path == fileDeleteCommand._path;
        }

        return false;
    }
}