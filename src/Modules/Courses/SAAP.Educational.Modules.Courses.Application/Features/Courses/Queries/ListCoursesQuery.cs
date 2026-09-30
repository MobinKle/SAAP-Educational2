using SAAP.Educational.Shared.CQRS;

namespace SAAP.Educational.Modules.Courses.Application.Features.Courses.Queries;

public sealed record ListCoursesQuery : IQuery<IReadOnlyList<CourseDto>>;
