using Itmo.ObjectOrientedProgramming.Lab4.Systems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeGotoCommand : ICommand
{
    private readonly string _path;

    public TreeGotoCommand(string path)
    {
        _path = path;
    }

    public void DoCommand(ISystem system)
    {
        system.TreeGoTo(_path);
    }

    public bool Equals(ICommand? other)
    {
        if (other is not TreeGotoCommand)
        {
            return false;
        }

        if (other is TreeGotoCommand treeGotoCommand)
        {
            return _path == treeGotoCommand._path;
        }

        return false;
    }
}