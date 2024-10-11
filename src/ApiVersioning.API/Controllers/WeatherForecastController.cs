using ApiVersioning.API.Constants;
using ApiVersioning.API.Entities;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace ApiVersioning.API.Controllers;

[ApiVersion(VersionConstants.DefaultApiVersion1)]
[ApiVersion(VersionConstants.ApiVersion2, Deprecated = true)]
[ApiVersion(VersionConstants.ApiVersion3)]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public sealed class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    [MapToApiVersion(VersionConstants.DefaultApiVersion1)]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<WeatherForecast>))]
    public IEnumerable<WeatherForecast> GetV1() =>
        GetRandomWeatherForecasts(HttpContext.GetRequestedApiVersion()!);

    [MapToApiVersion(VersionConstants.ApiVersion2)]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<WeatherForecast>))]
    public IEnumerable<WeatherForecast> GetV2() =>
        GetRandomWeatherForecasts(HttpContext.GetRequestedApiVersion()!);

    [MapToApiVersion(VersionConstants.ApiVersion3)]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<WeatherForecast>))]
    public IEnumerable<WeatherForecast> GetV3() =>
        GetRandomWeatherForecasts(HttpContext.GetRequestedApiVersion()!);

    private static IEnumerable<WeatherForecast> GetRandomWeatherForecasts(ApiVersion version) =>
        Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)],
            Version = (int)version.MajorVersion!
        });
}
