using payFlow.Application.Categories.DTOs.Requests;
using payFlow.Application.Categories.DTOs.Response;
using payFlow.Core.Models;

namespace payFlow.Application.Categories.Mappers
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
