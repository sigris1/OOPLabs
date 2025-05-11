using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileHandlers;

public class RenameFileCommandHandler : BaseFileCommandHandler
{
    private string? _path;
    private string? _name;

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

        if (now.Current != "rename")
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
            throw new Exception("Incorrect command");
        }

        _name = now.Current;
        if (now.MoveNext() is false)
        {
            return new FileRenameCommand(_path, _name);
        }

        throw new Exception("Incorrect command");
    }
}