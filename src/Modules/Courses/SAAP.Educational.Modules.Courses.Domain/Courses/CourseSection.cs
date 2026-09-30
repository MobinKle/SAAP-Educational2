using SAAP.Educational.Shared.Common;

namespace SAAP.Educational.Modules.Courses.Domain.Courses;

public sealed class CourseSection : Entity<Guid>
{
    private CourseSection(Guid id, string title, int order)
        : base(id)
    {
        Title = title;
        Order = order;
    }

    public string Title { get; private set; }

    public int Order { get; private set; }

    internal static CourseSection Create(Guid id, string title, int order)
    {
        return new CourseSection(id, title, order);
    }
}
