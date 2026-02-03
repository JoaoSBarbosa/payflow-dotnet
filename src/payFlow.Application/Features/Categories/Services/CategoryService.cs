using payFlow.Application.Common.Pageds;
using payFlow.Application.Exceptions;
using payFlow.Application.Features.Categories.Interfaces;
using payFlow.Application.Features.Categories.Mappers;
using payFlow.Application.Features.Categories.Ports;
using payFlow.Application.Features.Categories.Query;
using payFlow.Application.Features.Categories.Requests;
using payFlow.Application.Features.Categories.Response;
using payFlow.Application.Ports.Repositories;

namespace payFlow.Application.Features.Categories.Services
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
           return  new PagedResult<CategoryResponse>(
                items,
                result.TotalCount,
                result.Page,
                result.PageSize
             );

        }

        public async Task<CategoryResponse> GetById(long id)
        {
            if (id <= 0) throw new FieldNullException("Necessárion informar o id para busca");
            var entity = await _categoryRepository.GetById(id) ?? throw new NotFoundException($"Categoria {id} não encontrada");
            return CategoryMap.ToResponse(entity);
        }
    }
}
