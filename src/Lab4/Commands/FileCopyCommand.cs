using Itmo.ObjectOrientedProgramming.Lab4.Systems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileCopyCommand : ICommand
{
    private readonly string _pathFrom;
    private readonly string _pathTo;

    public FileCopyCommand(string pathFrom, string pathTo)
    {
        _pathFrom = pathFrom;
        _pathTo = pathTo;
    }

    public void DoCommand(ISystem system)
    {
        system.FileCopy(_pathFrom, _pathTo);
    }

    public bool Equals(ICommand? other)
    {
        if (other is not FileCopyCommand)
        {
            return false;
        }

        if (other is FileCopyCommand fileCopyCommand)
        {
            return _pathFrom == fileCopyCommand._pathFrom && _pathTo == fileCopyCommand._pathTo;
        }

        return false;
    }
}