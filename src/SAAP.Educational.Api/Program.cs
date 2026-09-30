using SAAP.Educational.Modules.Courses.Application;
using SAAP.Educational.Modules.Courses.Infrastructure;
using SAAP.Educational.Modules.Courses.Presentation.Controllers;
using SAAP.Educational.Shared.Mediator;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .AddApplicationPart(typeof(CoursesController).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationMediator();
builder.Services.AddCoursesApplication();
builder.Services.AddCoursesInfrastructure();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
