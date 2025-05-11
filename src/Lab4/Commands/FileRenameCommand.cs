using Itmo.ObjectOrientedProgramming.Lab4.Systems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileRenameCommand : ICommand
{
    private readonly string _path;
    private readonly string _name;

    public FileRenameCommand(string fileFrom, string fileTo)
    {
        _path = fileFrom;
        _name = fileTo;
    }

    public void DoCommand(ISystem system)
    {
        system.FileRename(_path, _name);
    }

    public bool Equals(ICommand? other)
    {
        if (other is not FileRenameCommand)
        {
            return false;
        }

        if (other is FileRenameCommand fileRenameCommand)
        {
            return _path == fileRenameCommand._path && _name == fileRenameCommand._name;
        }

        return false;
    }
}