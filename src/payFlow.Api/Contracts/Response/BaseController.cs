using Microsoft.AspNetCore.Mvc;
using payFlow.Api.Contracts.Errors;

namespace payFlow.Api.Contracts.Response
{

    [ApiController]
    public abstract class BaseController: ControllerBase
    {

        protected ActionResult ApiOk<T>(T data) => Ok(ApiResponse<T>.Ok(data));
        protected ActionResult ApiCreated<T>(T data, string actionName, object routValues) => CreatedAtAction(actionName, routValues, ApiResponse<T>.Ok(data));
        protected ActionResult ApiFail(IEnumerable<ApiError> errors, int statusCode = 400)
              => StatusCode(statusCode, ApiResponse<object>.Fail(errors));
    }
}
