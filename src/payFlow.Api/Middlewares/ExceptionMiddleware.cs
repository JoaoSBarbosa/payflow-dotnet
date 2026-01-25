using payFlow.Api.Contracts.Errors;
using payFlow.Api.Contracts.Response;

namespace payFlow.Api.Middlewares
{

    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
            => _next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (FluentValidation.ValidationException ex)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(
                    ApiResponse<object>.Fail(
                        ex.Errors.Select(e =>
                            new ApiError
                            {
                                Code = "VALIDATION_ERROR",
                                Message = e.ErrorMessage
                            })
                    )
                );
            }
            catch (ApplicationException ex)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(
                    ApiResponse<object>.Fail(new[]
                    {
                    new ApiError
                    {
                        Code = "APPLICATION_ERROR",
                        Message = ex.Message
                    }
                    })
                );
            }
            catch (Exception)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(
                    ApiResponse<object>.Fail(new[]
                    {
                    new ApiError
                    {
                        Code = "INTERNAL_ERROR",
                        Message = "Erro interno"
                    }
                    })
                );
            }
        }
    }

}
