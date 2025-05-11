using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileHandlers;

public class CopyFileCommandHandler : BaseFileCommandHandler
{
    private string? _pathFrom;
    private string? _pathTo;

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

        if (now.Current != "copy")
        {
            return null;
        }

        if (now.MoveNext() is false)
        {
            throw new Exception("Incorrect command");
        }

        _pathFrom = now.Current;
        if (now.MoveNext() is false)
        {
            throw new Exception("Incorrect command");
        }

        _pathTo = now.Current;
        if (now.MoveNext() is false)
        {
            return new FileCopyCommand(_pathFrom, _pathTo);
        }

        throw new Exception("Incorrect command");
    }
}