using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.StudyingParts;

public abstract class StudyingPart : IIdentify
{
    private User? _author;
    private string? _studyingPartName;
    private string? _studyingPartAssessment;
    private string? _studyingPartDescription;

    public Guid Id { get; protected set; }

    public string? StudyingPartName
    {
        get
        {
            return _studyingPartName;
        }

        protected set
        {
            ArgumentNullException.ThrowIfNull(value);
            _studyingPartName = value;
        }
    }

    public string StudyingPartAssessment
    {
        get
        {
            if (_studyingPartAssessment != null) return _studyingPartAssessment;
            throw new InvalidOperationException();
        }

        protected set
        {
            ArgumentNullException.ThrowIfNull(value);
            _studyingPartAssessment = value;
        }
    }

    public string StudyingPartDescription
    {
        get
        {
            if (_studyingPartDescription != null) return _studyingPartDescription;
            throw new InvalidOperationException();
        }

        protected set
        {
            ArgumentNullException.ThrowIfNull(value);
            _studyingPartDescription = value;
        }
    }

    public Guid? ClonedStudyingPartId { get; protected set; }

    public User? Author
    {
        get => _author;
        protected set
        {
            ArgumentNullException.ThrowIfNull(value);
            _author = value;
        }
    }

    public void DoChanges(User otherAuthor, string otherStudyingPartDescription)
    {
        if (otherAuthor.Id != Author?.Id)
        {
            throw new ArgumentException("Author is not the same as the author");
        }

        StudyingPartDescription = otherStudyingPartDescription;
    }

    public virtual StudyingPart CloneStudyingPart(Guid studyingPartId, User unclonedAuthor)
    {
        return this;
    }

    protected void SetClonedId(Guid clonedId)
    {
        ClonedStudyingPartId = clonedId;
    }
}