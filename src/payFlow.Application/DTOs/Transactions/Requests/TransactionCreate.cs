using payFlow.Core.Enums;

namespace payFlow.Application.DTOs.Transactions.Requests
{
    public record TransactionCreate(string Title, long CategoryId, decimal Amount, ETransactionType Type){ }
}
