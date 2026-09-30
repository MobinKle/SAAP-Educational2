using Microsoft.Extensions.DependencyInjection;
using SAAP.Educational.Modules.Courses.Domain.Courses;
using SAAP.Educational.Modules.Courses.Infrastructure.Persistence;
using SAAP.Educational.Modules.Courses.Infrastructure.Persistence.Courses;
using SAAP.Educational.Shared.Persistence;

namespace SAAP.Educational.Modules.Courses.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddCoursesInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<CourseStorage>();
        services.AddScoped<IQueryRepository<Course, Guid>, InMemoryCourseQueryRepository>();
        services.AddScoped<ICommandRepository<Course, Guid>, InMemoryCourseCommandRepository>();

        return services;
    }
}
