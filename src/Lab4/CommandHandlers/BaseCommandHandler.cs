using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers;

public abstract class BaseCommandHandler : ICommandHandler
{
    public ICommandHandler? NextHandler { get; private set; }

    public ICommandHandler AddNext(ICommandHandler commandHandler)
    {
        if (NextHandler == null)
        {
            NextHandler = commandHandler;
        }
        else
        {
            NextHandler.AddNext(commandHandler);
        }

        return NextHandler;
    }

    public abstract ICommand? Handle(string[] input);
}