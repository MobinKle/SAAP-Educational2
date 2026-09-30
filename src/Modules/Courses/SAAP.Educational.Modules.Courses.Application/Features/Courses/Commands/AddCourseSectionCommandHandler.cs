using SAAP.Educational.Modules.Courses.Domain.Courses;
using SAAP.Educational.Shared.CQRS;
using SAAP.Educational.Shared.Persistence;

namespace SAAP.Educational.Modules.Courses.Application.Features.Courses.Commands;

internal sealed class AddCourseSectionCommandHandler : ICommandHandler<AddCourseSectionCommand, CourseDto?>
{
    private readonly IQueryRepository<Course, Guid> _queryRepository;
    private readonly ICommandRepository<Course, Guid> _commandRepository;

    public AddCourseSectionCommandHandler(
        IQueryRepository<Course, Guid> queryRepository,
        ICommandRepository<Course, Guid> commandRepository)
    {
        _queryRepository = queryRepository;
        _commandRepository = commandRepository;
    }

    public async Task<CourseDto?> Handle(
        AddCourseSectionCommand request,
        CancellationToken cancellationToken)
    {
        var course = await _queryRepository.GetByIdAsync(request.CourseId, cancellationToken);
        if (course is null)
        {
            return null;
        }

        course.AddSection(request.Title);
        _commandRepository.Update(course);
        await _commandRepository.SaveChangesAsync(cancellationToken);

        return CourseDto.From(course);
    }
}
