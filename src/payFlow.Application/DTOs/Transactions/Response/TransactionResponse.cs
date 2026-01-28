namespace payFlow.Application.DTOs.Transactions.Response
{
    public record TransactionResponse(
        long Id ,
        string Title,
        DateTime CreatedAt,
        DateTime PaidOrReceivedAt,
        Decimal Amount,
        int Type,
        string CategoryName,
        long CategoryId,
        string UserId)
    {
    }
}
