using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.ConnectionHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.TreeHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Parser
{
    private readonly BaseCommandHandler _handler;

    public Parser()
    {
        _handler = new ConnectCommandHandler();
        _handler.AddNext(new DisconnectCommandHandler());
        _handler.AddNext(new CopyFileCommandHandler());
        _handler.AddNext(new DeleteFileCommandHandler());
        _handler.AddNext(new MoveFileCommandHandler());
        _handler.AddNext(new RenameFileCommandHandler());
        _handler.AddNext(new ShowFileCommandHandler());
        _handler.AddNext(new GotoTreeCommandHandler());
        _handler.AddNext(new ListTreeCommandHandler());
    }

    public ICommand? GetCommand(string input)
    {
        ArgumentNullException.ThrowIfNull(input);
        string[] now = input.Split(' ');
        BaseCommandHandler? currentChain = _handler;
        while (currentChain != null)
        {
            ICommand? currentCommand = currentChain.Handle(now);
            if (currentCommand != null)
            {
                return currentCommand;
            }

            if (currentChain.NextHandler == null)
            {
                return null;
            }

            currentChain = (BaseCommandHandler)currentChain.NextHandler;
        }

        return null;
    }
}