using SAAP.Educational.Modules.Courses.Domain.Courses;
using SAAP.Educational.Shared.Persistence;

namespace SAAP.Educational.Modules.Courses.Infrastructure.Persistence.Courses;

internal sealed class InMemoryCourseCommandRepository : ICommandRepository<Course, Guid>
{
    private readonly CourseStorage _storage;

    public InMemoryCourseCommandRepository(CourseStorage storage)
    {
        _storage = storage;
    }

    public Task AddAsync(Course entity, CancellationToken cancellationToken = default)
    {
        _storage.Courses.Add(entity);

        return Task.CompletedTask;
    }

    public void Update(Course entity)
    {
        var index = _storage.Courses.FindIndex(course => course.Id == entity.Id);
        if (index >= 0)
        {
            _storage.Courses[index] = entity;
        }
    }

    public void Remove(Course entity)
    {
        _storage.Courses.RemoveAll(course => course.Id == entity.Id);
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult(1);
    }
}
