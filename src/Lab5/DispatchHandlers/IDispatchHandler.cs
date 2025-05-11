using Commands;
using ResultTypes;
using UserRepository;
using Users;

namespace DispatchHandlers;

public interface IDispatchHandler
{
    IDispatchHandler AddNext(IDispatchHandler dispatchHandler);

    ResultType? Handle(IUser user, ICommand command, UsersRepository usersRepository);
}