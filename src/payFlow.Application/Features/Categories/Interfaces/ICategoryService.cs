using payFlow.Application.Common.Pageds;
using payFlow.Application.Features.Categories.Query;
using payFlow.Application.Features.Categories.Requests;
using payFlow.Application.Features.Categories.Response;

namespace payFlow.Application.Features.Categories.Interfaces
{
    public interface ICategoryService
    {
        Task<PagedResult<CategoryResponse>> GetAllAsync(CategoryFilter filter );
        Task<CategoryResponse> CreateCategory(CreateCategory category);
        Task<CategoryResponse> GetById(long id);
    }
}
