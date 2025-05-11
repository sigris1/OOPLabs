using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.TreeHandlers;

public class ListTreeCommandHandler : BaseTreeCommandHandler
{
    private int _depth;

    public override ICommand? Handle(string[] input)
    {
        IEnumerator<string> now = input.AsEnumerable().GetEnumerator();
        now.MoveNext();
        if (now.Current != "tree")
        {
            return null;
        }

        if (now.MoveNext() is false)
        {
            throw new Exception("Incorrect command");
        }

        if (now.Current != "list")
        {
             return null;
        }

        if (now.MoveNext() is false)
        {
            throw new Exception("Incorrect command");
        }

        if (now.Current != "-d")
        {
            throw new Exception("Incorrect command");
        }

        if (now.MoveNext() is false)
        {
            throw new Exception("Incorrect command");
        }

        _depth = int.Parse(now.Current);
        if (now.MoveNext() is false)
        {
            return new TreeListCommand(_depth);
        }

        throw new Exception("Incorrect command");
    }
}