using SAAP.Educational.Shared.Common;

namespace SAAP.Educational.Modules.Courses.Domain.Courses;

public sealed class Course : AggregateRoot<Guid>
{
    private readonly List<CourseSection> _sections = [];

    private Course(Guid id, string title, string description)
        : base(id)
    {
        Title = title;
        Description = description;
    }

    public string Title { get; private set; }

    public string Description { get; private set; }

    public IReadOnlyCollection<CourseSection> Sections => _sections.AsReadOnly();

    public static Course Create(string title, string description)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);

        return new Course(Guid.NewGuid(), title.Trim(), description.Trim());
    }

    public CourseSection AddSection(string title)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);

        var normalizedTitle = title.Trim();
        if (_sections.Any(section =>
                string.Equals(section.Title, normalizedTitle, StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidOperationException($"A section named '{normalizedTitle}' already exists.");
        }

        var section = CourseSection.Create(Guid.NewGuid(), normalizedTitle, _sections.Count + 1);
        _sections.Add(section);

        return section;
    }
}
