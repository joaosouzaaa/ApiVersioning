using ApiVersioning.API.Constants;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace ApiVersioning.API.Controllers.V2;

[ApiVersion(VersionConstants.ApiVersion2, Deprecated = true)]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public sealed class TestControllerV2 : ControllerBase
{
    [MapToApiVersion(VersionConstants.ApiVersion2)]
    [HttpGet("Version2")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetV2() =>
        Ok(HttpContext.GetRequestedApiVersion()!.MajorVersion);
}
