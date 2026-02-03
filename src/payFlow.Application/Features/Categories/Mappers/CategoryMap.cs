using payFlow.Application.Features.Categories.Requests;
using payFlow.Application.Features.Categories.Response;
using payFlow.Core.Models;

namespace payFlow.Application.Features.Categories.Mappers
{
    public static class CategoryMap
    {

        public static CategoryResponse ToResponse(Category category) => new CategoryResponse(
            category.Id,
            category.Title,
            category.Description?? string.Empty,
            category.UserId,
            category.CreatedAt
        );

        public static Category ToEntity(CreateCategory createCategory) => new Category(
            createCategory.Title,
            createCategory.UserId,
            createCategory.Description
        );
    }
}
