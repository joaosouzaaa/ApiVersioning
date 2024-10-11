namespace ApiVersioning.API.DependencyInjection;

internal static class DependencyInjectionHandler
{
    internal static void AddDependencyInjection(this IServiceCollection services)
    {
        services.AddCorsDependencyInjection();
        services.AddSwaggerDependencyInjection();
        services.AddVersioningDependencyInjection();
    }
}
