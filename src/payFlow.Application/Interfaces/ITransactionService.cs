using payFlow.Application.DTOs.Transactions.Response;
using payFlow.Core.Enums;

namespace payFlow.Application.Interfaces
{
    public interface ITransactionService
    {
        Task ProcessTransactionAsync(int userId, string title, decimal amount, ETransactionType type, long categoryId);
        Task<IEnumerable<TransactionResponse>> GetAllTransactionsAsync();
    }
}
