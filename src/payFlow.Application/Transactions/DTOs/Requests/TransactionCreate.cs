using payFlow.Core.Enums;

namespace payFlow.Application.Transactions.DTOs.Requests
{
    public record TransactionCreate(string Title, long CategoryId, decimal Amount, ETransactionType Type){ }
}
