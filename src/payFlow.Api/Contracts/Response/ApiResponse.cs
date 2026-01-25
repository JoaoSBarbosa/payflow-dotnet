using payFlow.Api.Contracts.Errors;

namespace payFlow.Api.Contracts.Response
{
    public class ApiResponse<T>
    {

        public bool Success { get; set; }
        public T? Data { get; set; }
        public IEnumerable<ApiError>? Erros { get; set; }
        
        public static ApiResponse<T> Ok(T data) => new() { Success = true, Data = data };
        public static ApiResponse<T> Fail(IEnumerable<ApiError> erros) => new() { Success = false, Erros = erros };
    }
}
