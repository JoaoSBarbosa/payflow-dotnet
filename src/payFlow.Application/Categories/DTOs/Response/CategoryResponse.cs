namespace payFlow.Application.Categories.DTOs.Response
{
    public record CategoryResponse(long Id, string Title, string Description, string UserId, DateTime CreatedAt)
    {
    }
}
