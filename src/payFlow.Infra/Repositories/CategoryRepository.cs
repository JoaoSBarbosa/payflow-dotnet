using Microsoft.EntityFrameworkCore;
using payFlow.Application.Categories.Ports;
using payFlow.Application.Categories.Query;
using payFlow.Application.Common.Pageds;
using payFlow.Application.Query;
using payFlow.Core.Models;
using payFlow.Infra.Data.Context;

namespace payFlow.Infra.Repositories
{
    public class CategoryRepository(PayFlowContext payFlowContext) : ICategoryRepository
    {
        private readonly PayFlowContext _payFlowContext = payFlowContext;

        
        public Task Create(Category category)
        {
           _payFlowContext.Categories.Add(category);

            return Task.CompletedTask;
        }

        public Task Delete(Category category)
        {
            _payFlowContext.Categories.Remove(category);
            return Task.CompletedTask;
        }

        public async Task<Category?> GetById(long id, bool asNoTracking)
        {
            IQueryable<Category> query = _payFlowContext.Categories;
            if (asNoTracking) query = query.AsNoTracking();

            return await query.Where(c => c.Id == id).FirstOrDefaultAsync();
        }



        public Task Update(Category category)
        {
            _payFlowContext.Categories.Update(category);

            return Task.CompletedTask;        
        }


        public async Task<PagedResult<Category>> GetPageCategory(CategoryFilter filter)
        {

            IQueryable<Category> query = _payFlowContext.Categories.AsNoTracking();

            query = ApplyFilters(query, filter);
            query = ApplyOrdering(query, filter);
            return await ApplyPagingAsync(query, filter);
        }

        private IQueryable<Category> ApplyFilters(IQueryable<Category> query, CategoryFilter filter)
        {
            if ( filter.Id.HasValue) query = query.Where( c => c.Id == filter.Id.Value);
            if(!string.IsNullOrWhiteSpace( filter.Title)) query = query.Where( c => c.Title.Contains( filter.Title!));
            if(!string.IsNullOrWhiteSpace( filter.Description)) query = query.Where( c => c.Description!.Contains( filter.Description!));

            return query;
        }

        private IQueryable<Category> ApplyOrdering(
            IQueryable<Category> query, 
            CategoryFilter filter)
        {
            return filter.OrderBy switch
            {
            
                ECategoryOrderBy.Title => filter.Descending ? query.OrderByDescending(c => c.Title) : query.OrderBy(c => c.Title),
                ECategoryOrderBy.Description => filter.Descending ? query.OrderByDescending(c => c.Description) : query.OrderBy(c => c.Description),
                ECategoryOrderBy.Id or _ => filter.Descending ? query.OrderByDescending(c => c.Id) : query.OrderBy(c => c.Id),
            };
        }

        private async Task<PagedResult<Category>> ApplyPagingAsync(IQueryable<Category> query, CategoryFilter filter)
        {
            var totalItems = await query.CountAsync();

            var items = await query
                .Skip(( filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            return new PagedResult<Category>(items, totalItems, filter.Page, filter.PageSize);
        }
    }
}
