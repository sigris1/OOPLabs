using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileHandlers;

public class DeleteFileCommandHandler : BaseFileCommandHandler
{
    private string? _path;

    public override ICommand? Handle(string[] input)
    {
        IEnumerator<string> now = input.AsEnumerable().GetEnumerator();
        now.MoveNext();
        if (now.Current != "file")
        {
             return null;
        }

        if (now.MoveNext() is false)
        {
            throw new Exception("Incorrect command");
        }

        if (now.Current != "delete")
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
            return new FileDeleteCommand(_path);
        }

        throw new Exception("Incorrect command");
    }
}