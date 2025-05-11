using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.StudyingParts;

public class Lecture : StudyingPart
{
    public Lecture(
        User author,
        Guid lectureId,
        string? lectureName,
        string lectureDescription,
        string lectureAssessment,
        Guid? clonedId)
    {
        if (author is not Lecturer)
        {
            throw new ArgumentException("author must be a Lecturer");
        }

        Author = author;
        Id = lectureId;
        ClonedStudyingPartId = clonedId;
        StudyingPartName = lectureName;
        StudyingPartDescription = lectureDescription;
        StudyingPartAssessment = lectureAssessment;
    }

    public override Lecture CloneStudyingPart(Guid studyingPartId, User unclonedAuthor)
    {
        return new Lecture(unclonedAuthor, studyingPartId, StudyingPartName, StudyingPartDescription, StudyingPartAssessment, Id);
    }
}
