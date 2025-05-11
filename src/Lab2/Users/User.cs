namespace Itmo.ObjectOrientedProgramming.Lab2.Users;

public abstract class User
{
    public string? Name { get; protected set; }

    public Guid Id { get; protected set; }
}