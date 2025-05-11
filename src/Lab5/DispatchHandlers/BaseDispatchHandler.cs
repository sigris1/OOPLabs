using Commands;
using ResultTypes;
using UserRepository;
using Users;

namespace DispatchHandlers;

public abstract class BaseDispatchHandler : IDispatchHandler
{
    public IDispatchHandler? NextHandler { get; private set; }

    public IDispatchHandler AddNext(IDispatchHandler dispatchHandler)
    {
        if (NextHandler == null)
        {
            NextHandler = dispatchHandler;
        }
        else
        {
            NextHandler.AddNext(dispatchHandler);
        }

        return NextHandler;
    }

    public abstract ResultType? Handle(IUser user, ICommand command, UsersRepository usersRepository);
}