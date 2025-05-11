using Itmo.ObjectOrientedProgramming.Lab4.Systems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeListCommand : ICommand
{
    private readonly int _depth;

    public TreeListCommand(int depth)
    {
        _depth = depth;
    }

    public void DoCommand(ISystem system)
    {
        system.TreeList(_depth);
    }

    public bool Equals(ICommand? other)
    {
        if (other is not TreeListCommand)
        {
            return false;
        }

        if (other is TreeListCommand treeListCommand)
        {
            return _depth == treeListCommand._depth;
        }

        return false;
    }
}