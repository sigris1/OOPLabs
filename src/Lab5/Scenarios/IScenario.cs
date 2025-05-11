using UserRepository;

namespace Scenarios;

public interface IScenario
{
    public string Name { get; }

    public void Run(UsersRepository usersRepository);
}