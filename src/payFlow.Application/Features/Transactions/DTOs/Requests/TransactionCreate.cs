using payFlow.Core.Enums;

namespace payFlow.Application.Features.Transactions.DTOs.Requests
{
    public record TransactionCreate(string Title, long CategoryId, decimal Amount, ETransactionType Type){ }
}
