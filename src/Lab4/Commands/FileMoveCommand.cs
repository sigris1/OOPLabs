using Itmo.ObjectOrientedProgramming.Lab4.Systems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileMoveCommand : ICommand
{
    private readonly string _pathFrom;
    private readonly string _pathTo;

    public FileMoveCommand(string pathFrom, string pathTo)
    {
        _pathFrom = pathFrom;
        _pathTo = pathTo;
    }

    public void DoCommand(ISystem system)
    {
        system.FileMove(_pathFrom, _pathTo);
    }

    public bool Equals(ICommand? other)
    {
        if (other is not FileMoveCommand)
        {
            return false;
        }

        if (other is FileMoveCommand fileMoveCommand)
        {
            return _pathFrom == fileMoveCommand._pathFrom && _pathTo == fileMoveCommand._pathTo;
        }

        return false;
    }
}