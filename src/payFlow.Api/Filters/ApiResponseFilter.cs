using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using payFlow.Api.Contracts.Response;

namespace payFlow.Api.Filters
{
    public class ApiResponseFilter : IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(
            ResultExecutingContext context,
            ResultExecutionDelegate next)
        {
            // Só empacota resultados 2xx
            if (context.Result is ObjectResult objectResult &&
                (objectResult.StatusCode is null or >= 200 and < 300))
            {
                // Evita empacotar duas vezes
                if (objectResult.Value is not ApiResponse<object>)
                {
                    context.Result = new ObjectResult(
                        ApiResponse<object>.Ok(objectResult.Value)
                    )
                    {
                        StatusCode = objectResult.StatusCode ?? StatusCodes.Status200OK
                    };
                }
            }

            await next();
        }
    }
}
