using Microsoft.OpenApi.Models;

namespace ApiVersioning.API.DependencyInjection;

internal static class SwaggerDependencyInjection
{
    internal static void AddSwaggerDependencyInjection(this IServiceCollection services) =>
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "API v1", Version = "v1" });
            options.SwaggerDoc("v2", new OpenApiInfo { Title = "API v2", Version = "v2" });
            options.SwaggerDoc("v3", new OpenApiInfo { Title = "API v3", Version = "v3" });
        });

    internal static void UseSwaggerDependencyInjection(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            options.SwaggerEndpoint("/swagger/v2/swagger.json", "v2");
            options.SwaggerEndpoint("/swagger/v3/swagger.json", "v3");
        });
    }
}
