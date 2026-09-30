using SAAP.Educational.Modules.Courses.Domain.Courses;

namespace SAAP.Educational.Modules.Courses.Infrastructure.Persistence;

internal sealed class CourseStorage
{
    public CourseStorage()
    {
        var architectureCourse = Course.Create(
            "Onion Architecture",
            "Layered architecture sample for SAAP Educational.");
        architectureCourse.AddSection("Domain model");
        architectureCourse.AddSection("Application layer");

        var cqrsCourse = Course.Create(
            "CQRS with MediatR",
            "Command and query separation with shared abstractions.");
        cqrsCourse.AddSection("Commands");
        cqrsCourse.AddSection("Queries");

        Courses = [architectureCourse, cqrsCourse];
    }

    public List<Course> Courses { get; }
}
