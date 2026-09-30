using SAAP.Educational.Modules.Courses.Domain.Courses;
using SAAP.Educational.Shared.CQRS;
using SAAP.Educational.Shared.Persistence;

namespace SAAP.Educational.Modules.Courses.Application.Features.Courses.Queries;

internal sealed class ListCoursesQueryHandler : IQueryHandler<ListCoursesQuery, IReadOnlyList<CourseDto>>
{
    private readonly IQueryRepository<Course, Guid> _courseRepository;

    public ListCoursesQueryHandler(IQueryRepository<Course, Guid> courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<IReadOnlyList<CourseDto>> Handle(ListCoursesQuery request, CancellationToken cancellationToken)
    {
        var courses = await _courseRepository.ListAsync(cancellationToken);

        return courses
            .Select(CourseDto.From)
            .ToList();
    }
}
