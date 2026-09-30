using SAAP.Educational.Modules.Courses.Domain.Courses;
using SAAP.Educational.Shared.Persistence;

namespace SAAP.Educational.Modules.Courses.Infrastructure.Persistence.Courses;

internal sealed class InMemoryCourseQueryRepository : IQueryRepository<Course, Guid>
{
    private readonly CourseStorage _storage;

    public InMemoryCourseQueryRepository(CourseStorage storage)
    {
        _storage = storage;
    }

    public Task<Course?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_storage.Courses.FirstOrDefault(course => course.Id == id));
    }

    public Task<IReadOnlyList<Course>> ListAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult<IReadOnlyList<Course>>(_storage.Courses);
    }
}
