using payFlow.Application.Categories.DTOs.Requests;
using payFlow.Application.Categories.DTOs.Response;
using payFlow.Application.Categories.Interfaces;
using payFlow.Application.Categories.Mappers;
using payFlow.Application.Categories.Ports;
using payFlow.Application.Categories.Query;
using payFlow.Application.Common.Pageds;
using payFlow.Application.Ports.Repositories;
using payFlow.Core.Models;

namespace payFlow.Application.Categories.Services
{
    public class CategoryService(ICategoryRepository categoryRepository, IUnitOfWork commit) : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        private readonly IUnitOfWork _commit = commit;

        public async Task<CategoryResponse> CreateCategory(CreateCategory category)
        {
            var entity = CategoryMap.ToEntity(category);
            if (entity == null) throw new ApplicationException("Erro ao cadatrar categoria");

            await _categoryRepository.Create(entity);

            await _commit.CommitAsync();

            return CategoryMap.ToResponse(entity);
        }

        public async Task<PagedResult<CategoryResponse>> GetAllAsync(CategoryFilter filter)
        {
            var result = await _categoryRepository.GetPageCategory(filter);
            
            var items = result.Items.Select( c => CategoryMap.ToResponse(c)).ToList();
            return new PagedResult<CategoryResponse>(
                items,
                result.TotalCount,
                result.Page,
                result.PageSize
             );
        }

        public Task<CategoryResponse> GetById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
