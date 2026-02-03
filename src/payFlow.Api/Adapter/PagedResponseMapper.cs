using payFlow.Api.Contracts.Page;
using payFlow.Application.Common.Pageds;

namespace payFlow.Api.Adapter
{
    public static class PagedResponseMapper
    {

        public static PagedResponse<T> From<T>(PagedResult<T> result)
        {
            var pagination = new PaginationMeta
            {
                Page = result.Page,
                PageSize = result.PageSize,
                TotalCount = result.TotalCount,
                TotalPages = result.TotalPages,
            };
            return new PagedResponse<T>
            {
                Items = result.Items,
                Pagination = pagination,
            };

        }
    }
}
