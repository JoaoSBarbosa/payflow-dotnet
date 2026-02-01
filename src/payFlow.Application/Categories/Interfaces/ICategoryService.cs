using payFlow.Application.Categories.DTOs.Requests;
using payFlow.Application.Categories.DTOs.Response;
using payFlow.Application.Categories.Query;
using payFlow.Application.Common.Pageds;

namespace payFlow.Application.Categories.Interfaces
{
    public interface ICategoryService
    {
        Task<PagedResult<CategoryResponse>> GetAllAsync(CategoryFilter filter );
        Task<CategoryResponse> CreateCategory(CreateCategory category);
        Task<CategoryResponse> GetById(long id);
    }
}
