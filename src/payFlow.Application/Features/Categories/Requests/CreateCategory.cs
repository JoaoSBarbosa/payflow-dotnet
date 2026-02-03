namespace payFlow.Application.Features.Categories.Requests
{
    public record CreateCategory(string Title, string? Description, string UserId) { }
}
