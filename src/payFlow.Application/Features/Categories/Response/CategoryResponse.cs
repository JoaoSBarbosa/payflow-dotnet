namespace payFlow.Application.Features.Categories.Response
{
    public record CategoryResponse(long Id, string Title, string Description, string UserId, DateTime CreatedAt)
    {
    }
}
