namespace payFlow.Api.Contracts.Page
{
    public sealed class PagedResponse<T>
    {
        public IReadOnlyList<T> Items { get; set; }
        public PaginationMeta Pagination { get; init; } = default!;
    }
}
