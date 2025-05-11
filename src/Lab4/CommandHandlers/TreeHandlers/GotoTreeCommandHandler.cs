using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.TreeHandlers;

public class GotoTreeCommandHandler : BaseCommandHandler
{
    private string? _path;

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

        if (now.Current != "goto")
        {
            return null;
        }

        if (now.MoveNext() is false)
        {
            throw new Exception("Incorrect command");
        }

        _path = now.Current;
        if (now.MoveNext() is false)
        {
            return new TreeGotoCommand(_path);
        }

        throw new Exception("Incorrect command");
    }
}