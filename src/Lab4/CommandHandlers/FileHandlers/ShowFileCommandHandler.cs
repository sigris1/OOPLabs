using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileHandlers;

public class ShowFileCommandHandler : BaseFileCommandHandler
{
    private string? _path;
    private string? _mode;

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

        if (now.Current != "show")
        {
            throw new Exception("Incorrect command");
        }

        if (now.MoveNext() is false)
        {
            throw new Exception("Incorrect command");
        }

        _path = now.Current;
        if (now.MoveNext() is false)
        {
            throw new Exception("Incorrect command");
        }

        if (now.Current != "-m")
        {
            throw new Exception("Incorrect command");
        }

        if (now.MoveNext() is false)
        {
            throw new Exception("Incorrect command");
        }

        _mode = now.Current;
        if (now.MoveNext() is false)
        {
            return new FileShowCommand(_path, _mode);
        }

        throw new Exception("Incorrect command");
    }
}