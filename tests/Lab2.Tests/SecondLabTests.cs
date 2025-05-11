using Itmo.ObjectOrientedProgramming.Lab2;
using Itmo.ObjectOrientedProgramming.Lab2.ProgramParts;
using Itmo.ObjectOrientedProgramming.Lab2.StudyingParts;
using Itmo.ObjectOrientedProgramming.Lab2.TestFormats;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Xunit;

namespace Lab2.Tests;

public class SecondLabTests
{
    [Fact]
    public void TryingChangesNotByAuthor()
    {
        var myFirstLecturer = new Lecturer(Guid.NewGuid(), "My First Lecture");
        var mySecondLecturer = new Lecturer(Guid.NewGuid(), "My Second Lecture");
        var myLecture = new Lecture(myFirstLecturer, Guid.NewGuid(), "name", "description", "assessment", null);
        Assert.Throws<ArgumentException>(() => { myLecture.DoChanges(mySecondLecturer, "New Information"); });
    }

    [Fact]
    public void ThereIsIdentifierOfOriginalObject()
    {
        var now = Guid.NewGuid();
        var myFirstLecturer = new Lecturer(Guid.NewGuid(), "My First Lecture");
        var myLecture = new Lecture(myFirstLecturer, now,  "name", "description", "assessment", null);
        Lecture myCopiedLecture = myLecture.CloneStudyingPart(now, myFirstLecturer);
        Assert.Equal(myLecture.Id, myCopiedLecture.ClonedStudyingPartId);
    }

    [Fact]
    public void ValidPointsCount()
    {
        var myFirstLecturer = new Lecturer(Guid.NewGuid(), "My First Lecture");
        var myFirstStudent = new Student(Guid.NewGuid(), "My first student");
        var myLabwork = new LabWork(myFirstStudent, Guid.NewGuid(), "First labwork", "Test", "Assessment", 99, null);
        var myLecture = new Lecture(myFirstLecturer, Guid.NewGuid(), "name", "description", "assessment", null);
        ICollection<LabWork> labWorks = new[] { myLabwork };
        ICollection<Lecture> lectures = new[] { myLecture };
        Assert.Throws<ArgumentException>(() =>
        {
            Subject mySubject = Subject.Builder
            .WithId(Guid.NewGuid())
            .WithLecturer(myFirstLecturer)
            .WithLabWorks(labWorks)
            .WithLectures(lectures)
            .WithTestFormat(new Exam(12))
            .Build();
        });
    }

    [Fact]
    public void CreatingEducationalProgram()
    {
        var myFirstSupervisor = new Supervisor(Guid.NewGuid(), "My First supervisor");
        var myFirstLecturer = new Lecturer(Guid.NewGuid(), "My First Lecture");
        var myFirstStudent = new Student(Guid.NewGuid(), "My first student");
        var myLabwork = new LabWork(myFirstStudent, Guid.NewGuid(), "First labwork", "Test", "Assessment", 99, null);
        var myLecture = new Lecture(myFirstLecturer, Guid.NewGuid(), "name", "description", "assessment", null);
        ICollection<LabWork> labWorks = new[] { myLabwork };
        ICollection<Lecture> lectures = new[] { myLecture };
        Subject mySubject = Subject.Builder
            .WithId(Guid.NewGuid())
            .WithLecturer(myFirstLecturer)
            .WithLabWorks(labWorks)
            .WithLectures(lectures)
            .WithTestFormat(new Exam(1))
            .Build();
        ICollection<Subject> subjects = new[] { mySubject };
        EducationalProgram educationalProgram = EducationalProgram.Builder.WithId(Guid.NewGuid()).WithName("name").WithUser(myFirstSupervisor).WithSubject(subjects).Build();
    }
}