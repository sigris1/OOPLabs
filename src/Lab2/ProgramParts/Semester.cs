using Itmo.ObjectOrientedProgramming.Lab2.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab2.ProgramParts;

public class Semester : IIdentify
{
    private Repository<Subject> _semesterSubjects;

    public Semester(string name, ICollection<Subject> semesterSubjects, Guid semesterNumber)
    {
        ArgumentNullException.ThrowIfNull(name);
        SemesterName = name;
        Id = semesterNumber;
        SemesterSubjects = new Repository<Subject>(semesterSubjects);
        _semesterSubjects = SemesterSubjects;
    }

    public Guid Id { get; }

    public string SemesterName { get; private set; }

    public Repository<Subject> SemesterSubjects
    {
        get => _semesterSubjects;
        private set
        {
            ArgumentNullException.ThrowIfNull(value);
            _semesterSubjects = value;
        }
    }
}