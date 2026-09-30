using Microsoft.AspNetCore.Mvc;
using SAAP.Educational.Modules.Courses.Application.Features.Courses;
using SAAP.Educational.Modules.Courses.Application.Features.Courses.Commands;
using SAAP.Educational.Modules.Courses.Application.Features.Courses.Queries;
using SAAP.Educational.Modules.Courses.Contracts.Courses;
using SAAP.Educational.Shared.Mediator;

namespace SAAP.Educational.Modules.Courses.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class CoursesController : ControllerBase
{
    private readonly IApplicationMediator _mediator;

    public CoursesController(IApplicationMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<CourseDto>>> List(CancellationToken cancellationToken)
    {
        var courses = await _mediator.QueryAsync(new ListCoursesQuery(), cancellationToken);

        return Ok(courses);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CourseDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var course = await _mediator.QueryAsync(new GetCourseByIdQuery(id), cancellationToken);

        return course is null ? NotFound() : Ok(course);
    }

    [HttpPost]
    public async Task<ActionResult<CourseDto>> Create(
        CreateCourseRequest request,
        CancellationToken cancellationToken)
    {
        var course = await _mediator.SendAsync(
            new CreateCourseCommand(request.Title, request.Description),
            cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id = course.Id }, course);
    }

    [HttpPost("{id:guid}/sections")]
    public async Task<ActionResult<CourseDto>> AddSection(
        Guid id,
        AddCourseSectionRequest request,
        CancellationToken cancellationToken)
    {
        var course = await _mediator.SendAsync(
            new AddCourseSectionCommand(id, request.Title),
            cancellationToken);

        return course is null ? NotFound() : Ok(course);
    }
}
