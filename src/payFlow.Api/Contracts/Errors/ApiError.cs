namespace payFlow.Api.Contracts.Errors
{
    public record class ApiError(int Code, string Error, string Message) { }
}
