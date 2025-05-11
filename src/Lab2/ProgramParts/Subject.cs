using Itmo.ObjectOrientedProgramming.Lab2.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.StudyingParts;
using Itmo.ObjectOrientedProgramming.Lab2.TestFormats;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.ProgramParts;

public class Subject : IIdentify
{
    public class SubjectBuilder
    {
        private Guid _id;
        private User? _lecturer;
        private ICollection<LabWork>? _labWorks;
        private ICollection<Lecture>? _lectures;
        private TestFormat? _testFormat;

        public SubjectBuilder WithId(Guid id)
        {
            _id = id;
            return this;
        }

        public SubjectBuilder WithLectures(ICollection<Lecture> lectures)
        {
            ArgumentNullException.ThrowIfNull(lectures);
            _lectures = lectures;
            return this;
        }

        public SubjectBuilder WithLecturer(User lecturer)
        {
            ArgumentNullException.ThrowIfNull(lecturer);
            _lecturer = lecturer;
            return this;
        }

        public SubjectBuilder WithLabWorks(ICollection<LabWork> labWorks)
        {
            ArgumentNullException.ThrowIfNull(labWorks);
            _labWorks = labWorks;
            return this;
        }

        public SubjectBuilder WithTestFormat(TestFormat testFormat)
        {
            _testFormat = testFormat;
            return this;
        }

        public Subject Build()
        {
            ArgumentNullException.ThrowIfNull(_lecturer);
            ArgumentNullException.ThrowIfNull(_labWorks);
            ArgumentNullException.ThrowIfNull(_lectures);
            ArgumentNullException.ThrowIfNull(_testFormat);
            return new Subject(_id, _lecturer, _labWorks, _lectures, _testFormat, null);
        }
    }

    public static SubjectBuilder Builder => new SubjectBuilder();

    private Subject(Guid id, User lecturer, ICollection<LabWork> labWorks, ICollection<Lecture> lecturers, TestFormat format, Guid? clonedId)
    {
        Id = id;
        ClonedId = clonedId;
        if (lecturer is not Lecturer)
        {
            throw new ArgumentException("Author is not Lecturer");
        }

        SubjectLecturer = lecturer;
        SubjectLabWorks = new Repository<LabWork>(labWorks);
        SubjectLectures = new Repository<Lecture>(lecturers);
        SubjectTestFormat = format;
        _subjectTestFormat = SubjectTestFormat;
        _subjectLabWorks = SubjectLabWorks;
        _subjectLectures = SubjectLectures;
        CheckCorrection();
    }

    public Guid Id { get; }

    public Guid? ClonedId { get; }

    public User SubjectLecturer { get; }

    public TestFormat SubjectTestFormat
    {
        get => _subjectTestFormat;
        private set
        {
            ArgumentNullException.ThrowIfNull(value);
            _subjectTestFormat = value;
        }
    }

    public Repository<LabWork> SubjectLabWorks
    {
        get => _subjectLabWorks;
        private set
        {
            ArgumentNullException.ThrowIfNull(value);
            _subjectLabWorks = value;
        }
    }

    public Repository<Lecture> SubjectLectures
    {
        get => _subjectLectures;
        private set
        {
            ArgumentNullException.ThrowIfNull(value);
            _subjectLectures = value;
        }
    }

    public Subject CloneSubject(Guid subjectId, User unclonedAuthor)
    {
        return new Subject(subjectId, unclonedAuthor, SubjectLabWorks.Objects, SubjectLectures.Objects, SubjectTestFormat, Id);
    }

    public void DoChanges(User otherAuthor, ICollection<LabWork> labWorks, ICollection<Lecture> lectures)
    {
        if (otherAuthor.Id != SubjectLecturer.Id)
        {
            throw new ArgumentException("Author is not the same as the author");
        }

        SubjectLabWorks = new Repository<LabWork>(labWorks);
        SubjectLectures = new Repository<Lecture>(lectures);
    }

    private void CheckCorrection()
    {
        ICollection<LabWork>? labWorks = SubjectLabWorks.Objects;
        int temp = labWorks.Sum(labWork => labWork.LabWorkPoints);

        if (_subjectTestFormat is Exam)
        {
            temp += _subjectTestFormat.PointsCount;
        }

        if (temp != 100)
        {
            throw new ArgumentException("Wrong maximal number of points");
        }
    }

    private TestFormat _subjectTestFormat;
    private Repository<LabWork> _subjectLabWorks;
    private Repository<Lecture> _subjectLectures;
}
