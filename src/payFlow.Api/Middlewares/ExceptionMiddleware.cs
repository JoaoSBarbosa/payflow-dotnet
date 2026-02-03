using payFlow.Api.Contracts.Errors;
using payFlow.Api.Contracts.Response;
using payFlow.Application.Exceptions;

namespace payFlow.Api.Middlewares;

public sealed class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (FluentValidation.ValidationException ex)
        {
            await WriteErrorAsync(
                context,
                StatusCodes.Status400BadRequest,
                ex.Errors.Select(e =>
                    new ApiError(StatusCodes.Status400BadRequest, "VALIDATION_ERROR", e.ErrorMessage))
            );
        }
        catch (BusinessException ex)
        {
            await WriteErrorAsync(
                context,
                StatusCodes.Status400BadRequest,
                new[] { new ApiError(StatusCodes.Status400BadRequest, "BUSINESS_ERROR", ex.Message) }
            );
        }
        catch (NotFoundException ex)
        {
            await WriteErrorAsync(
                context,
                StatusCodes.Status404NotFound,
                new[] { new ApiError(StatusCodes.Status400BadRequest, "NOT_FOUND", ex.Message) }
            );
        }
        catch (FieldNullException ex)
        {
            await WriteErrorAsync(context, StatusCodes.Status400BadRequest, new[] { new ApiError(StatusCodes.Status400BadRequest, "BAD_REQUEST", ex.Message) });
        }
        catch (ApplicationExceptionBase)
        {
            await WriteErrorAsync(
                context,
                StatusCodes.Status500InternalServerError,
                new[] { new ApiError(StatusCodes.Status400BadRequest, "INTERNAL_ERROR", "Erro interno") }
            );
        }
    }


    private static async Task WriteErrorAsync(
        HttpContext context,
        int statusCode,
        IEnumerable<ApiError> errors)
    {
        context.Response.Clear();
        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/json";

        await context.Response.WriteAsJsonAsync(
            ApiResponse<object>.Fail(errors)
        );
    }
}
