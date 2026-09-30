using SAAP.Educational.Shared.CQRS;

namespace SAAP.Educational.Modules.Courses.Application.Features.Courses.Commands;

public sealed record AddCourseSectionCommand(Guid CourseId, string Title) : ICommand<CourseDto?>;
