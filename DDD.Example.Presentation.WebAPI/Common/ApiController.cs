using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DDD.Example.Presentation.WebAPI.Common;

public class ApiController<TResponse> : ControllerBase
{
    [ApiExplorerSettings(IgnoreApi = true)]
    protected IActionResult Problem(List<Error> errors)
    {
        if (errors.All(error => error.Type == ErrorType.Validation))
        {
            return ValidateProblems(errors);
        }

        HttpContext.Items["errors"] = errors;

        var firstError = errors[0];
        return Problem(firstError);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult Problem(Error error)
    {
        var statusCode = error.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(statusCode: statusCode, title: error.Description);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult ValidateProblems(List<Error> errors)
    {
        var modelStateDictionary = new ModelStateDictionary();
        foreach (var error in errors)
        {
            modelStateDictionary.AddModelError(error.Code, error.Description);
        }

        return ValidationProblem(modelStateDictionary);
    }

    /// <summary>
    /// Return Ok response with return object. This method dynamically cast from any T from mediatr
    /// to TResponse defined in ApiController constraint.
    /// </summary>
    /// <remarks>result param is casted to <see cref="TResponse"/> by dynamic keyword.
    /// Make sure <see cref="TResponse"/> have casting operators!</remarks>
    /// <param name="result">TResponse</param>
    /// <typeparam name="T">TMediatrResult (dynamically from compiler and not used)</typeparam>
    /// <returns></returns>
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult Ok<T>(T? result)
    {
        // base. is need for do not stack overflow by recursive method calls.
        return base.Ok((TResponse?)(dynamic?)result);
    }

    // [ApiExplorerSettings(IgnoreApi = true)]
    // public IActionResult Created<T>(T? result)
    // {
    //     // base. is need for do not stack overflow by recursive method calls.
    //     return base.Created((TResponse?)(dynamic?)result);
    // }
}