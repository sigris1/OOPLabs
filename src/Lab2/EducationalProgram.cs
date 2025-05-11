using Itmo.ObjectOrientedProgramming.Lab2.ProgramParts;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class EducationalProgram : IIdentify
{
    public class EducationalProgramBuilder
    {
        private Guid _id;
        private User? _user;
        private string? _name;
        private ICollection<Subject>? _subjects;

        public EducationalProgramBuilder WithId(Guid id)
        {
            _id = id;
            return this;
        }

        public EducationalProgramBuilder WithUser(User user)
        {
            _user = user;
            return this;
        }

        public EducationalProgramBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public EducationalProgramBuilder WithSubject(ICollection<Subject> subject)
        {
            _subjects = subject;
            return this;
        }

        public EducationalProgram Build()
        {
            ArgumentNullException.ThrowIfNull(_subjects);
            ArgumentNullException.ThrowIfNull(_name);
            ArgumentNullException.ThrowIfNull(_user);
            return new EducationalProgram(_user, _id, _name);
        }
    }

    private User _author;

    public static EducationalProgramBuilder Builder => new EducationalProgramBuilder();

    private EducationalProgram(User author, Guid id, string name)
    {
        if (author is not Supervisor)
        {
            throw new ArgumentException("Author is not Supervisor");
        }

        Author = author;
        Id = id;
        _author = Author;
    }

    public Guid Id { get; }

    public User Author
    {
        get => _author;
        protected set
        {
            ArgumentNullException.ThrowIfNull(value);
            _author = value;
        }
    }
}