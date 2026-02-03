namespace payFlow.Application.Features.Transactions.DTOs.Response
{
    public record TransactionResponse(
        long Id ,
        string Title,
        DateTime CreatedAt,
        DateTime PaidOrReceivedAt,
        decimal Amount,
        int Type,
        string CategoryName,
        long CategoryId,
        string UserId)
    {
    }
}
