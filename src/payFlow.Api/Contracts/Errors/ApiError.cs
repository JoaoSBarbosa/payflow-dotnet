namespace payFlow.Api.Contracts.Errors
{
    public sealed class ApiError
    {
        public string Code { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
