using Microsoft.Extensions.DependencyInjection;

namespace SAAP.Educational.Shared.Mediator;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationMediator(this IServiceCollection services)
    {
        services.AddScoped<IApplicationMediator, ApplicationMediator>();

        return services;
    }
}
