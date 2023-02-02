using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Example.Presentation.WebAPI.Common;

[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorController : ApiController<ObjectResult>
{
    private readonly ILogger<ErrorController> _logger;

    public ErrorController(ILogger<ErrorController> logger)
    {
        _logger = logger;
    }

    [Route("/error")]
    public IActionResult HandleError()
    {
        var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        if (exception is not null)
        {
            _logger.LogError(exception, "Error while trying to process an request: {Message}", exception.Message);
        }

        return Problem();
    }
}