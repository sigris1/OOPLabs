using Commands;
using DispatchHandlers;
using ResultTypes;
using UserRepository;
using Users;

namespace CommandDispather;

public class Dispatcher
{
    private readonly BaseDispatchHandler _handler;

    public Dispatcher()
    {
        _handler = new CreateUserDispatchHandler();
        _handler.AddNext(new LoginDispatchHandler());
        _handler.AddNext(new DepositDispatchHandler());
        _handler.AddNext(new WithdrawDispatchHandler());
        _handler.AddNext(new GetBalanceDispatchHandler());
        _handler.AddNext(new GetOperationsDispatchHandler());
        _handler.AddNext(new AccessDispatchHandler());
    }

    public ResultType Dispatch(long userId, ICommand command, UsersRepository userRepository)
    {
        BaseDispatchHandler? currentChain = _handler;
        while (currentChain != null)
        {
            if (command is not CreateUserCommand)
            {
                IUser? user = GetUser(userId, userRepository);
                if (user == null)
                {
                    return new ResultType.BadResultNonExistentUser();
                }

                ResultType? currentResult = currentChain.Handle(user, command, userRepository);
                if (currentResult != null)
                {
                    return currentResult;
                }

                if (currentChain.NextHandler == null)
                {
                    return new ResultType.BadResultWrongCommand();
                }

                currentChain = (BaseDispatchHandler)currentChain.NextHandler;
            }
            else
            {
                var currentCommand = (CreateUserCommand)command;

                Task<long> current = userRepository.AddInform(currentCommand.UserPin, 0);
                return new ResultType.GoodResult(0, "Created new user");
            }
        }

        return new ResultType.BadResultWrongCommand();
    }

    private IUser? GetUser(long userId, UsersRepository userRepository)
    {
        Task<IUser?> current = userRepository.FindUserByUserId(userId);
        return current?.Result;
    }
}