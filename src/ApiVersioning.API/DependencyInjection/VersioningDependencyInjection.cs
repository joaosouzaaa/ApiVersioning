using ApiVersioning.API.Constants;
using Asp.Versioning;

namespace ApiVersioning.API.DependencyInjection;

internal static class VersioningDependencyInjection
{
    internal static void AddVersioningDependencyInjection(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.ReportApiVersions = true;
            options.DefaultApiVersion = new ApiVersion(
                VersionConstants.DefaultApiVersion1, 
                VersionConstants.ApiMinorVersion);
            options.AssumeDefaultVersionWhenUnspecified = true;
        })
        .AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });
    }
}
