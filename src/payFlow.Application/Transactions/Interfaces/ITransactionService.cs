using payFlow.Application.Transactions.DTOs.Response;
using payFlow.Core.Enums;

namespace payFlow.Application.Transactions.Interfaces
{
    public interface ITransactionService
    {
        Task ProcessTransactionAsync(int userId, string title, decimal amount, ETransactionType type, long categoryId);
        Task<IEnumerable<TransactionResponse>> GetAllTransactionsAsync();
    }
}
