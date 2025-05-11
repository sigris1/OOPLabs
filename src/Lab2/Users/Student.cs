namespace Itmo.ObjectOrientedProgramming.Lab2.Users;

public class Student : User
{
    public Student(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}