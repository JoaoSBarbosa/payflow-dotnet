using payFlow.Application.Common.Pageds;
using payFlow.Application.Features.Categories.Query;
using payFlow.Core.Models;

namespace payFlow.Application.Features.Categories.Ports
{
    public interface ICategoryRepository
    {
        Task<PagedResult<Category>> GetPageCategory(CategoryFilter filter);
        Task<Category?> GetById(long id, bool asNoTracking = false);
        Task Create(Category category);
        Task Update(Category category);
        Task Delete(Category category);
    }
}
