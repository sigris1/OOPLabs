using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.StudyingParts;

public class LabWork : StudyingPart
{
    public LabWork(
        User author,
        Guid labworkId,
        string? labworkName,
        string labworkeDescription,
        string labworkAssessment,
        int labWorkPoints,
        Guid? clonedId)
    {
        if (author is not Student)
        {
            throw new ArgumentException("author must be a Student");
        }

        Author = author;
        Id = labworkId;
        ClonedStudyingPartId = clonedId;
        StudyingPartName = labworkName;
        StudyingPartDescription = labworkeDescription;
        StudyingPartAssessment = labworkAssessment;
        LabWorkPoints = labWorkPoints;
    }

    public int LabWorkPoints { get; }

    public override LabWork CloneStudyingPart(Guid studyingPartId, User unclonedAuthor)
    {
        return new LabWork(unclonedAuthor, studyingPartId, StudyingPartName, StudyingPartDescription, StudyingPartAssessment, LabWorkPoints, Id);
    }
}
