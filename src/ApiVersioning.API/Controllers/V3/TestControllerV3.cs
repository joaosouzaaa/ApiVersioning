using ApiVersioning.API.Constants;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace ApiVersioning.API.Controllers.V3;

[ApiVersion(VersionConstants.ApiVersion3)]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public sealed class TestControllerV3 : ControllerBase
{
    [MapToApiVersion(VersionConstants.ApiVersion3)]
    [HttpGet("Version3")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetV3() =>
        Ok(HttpContext.GetRequestedApiVersion()!.MajorVersion);
}
