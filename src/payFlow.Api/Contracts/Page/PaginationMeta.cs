namespace payFlow.Api.Contracts.Page
{
    public sealed class PaginationMeta
    {
        public int Page { get; init; }
        public int PageSize { get; init; }
        public int TotalCount { get; init; }
        public int TotalPages { get; init; }


        public PaginationMeta() { }
    }
}
