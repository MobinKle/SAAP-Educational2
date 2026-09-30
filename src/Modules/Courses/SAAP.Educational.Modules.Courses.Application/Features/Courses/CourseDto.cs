using SAAP.Educational.Modules.Courses.Domain.Courses;

namespace SAAP.Educational.Modules.Courses.Application.Features.Courses;

public sealed record CourseDto(
    Guid Id,
    string Title,
    string Description,
    IReadOnlyList<CourseSectionDto> Sections)
{
    public static CourseDto From(Course course)
    {
        var sections = course.Sections
            .OrderBy(section => section.Order)
            .Select(section => new CourseSectionDto(section.Id, section.Title, section.Order))
            .ToList();

        return new CourseDto(course.Id, course.Title, course.Description, sections);
    }
}

public sealed record CourseSectionDto(Guid Id, string Title, int Order);
