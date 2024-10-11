using ApiVersioning.API.Constants;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace ApiVersioning.API.Controllers.V1;

[ApiVersion(VersionConstants.DefaultApiVersion1)]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public sealed class TestControllerV1 : ControllerBase
{
    [MapToApiVersion(VersionConstants.DefaultApiVersion1)]
    [HttpGet("Version1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetV1() =>
        Ok(HttpContext.GetRequestedApiVersion()!.MajorVersion);
}
