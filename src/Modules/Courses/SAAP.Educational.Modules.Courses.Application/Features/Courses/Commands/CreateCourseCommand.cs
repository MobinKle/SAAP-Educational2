using SAAP.Educational.Shared.CQRS;

namespace SAAP.Educational.Modules.Courses.Application.Features.Courses.Commands;

public sealed record CreateCourseCommand(string Title, string Description) : ICommand<CourseDto>;
