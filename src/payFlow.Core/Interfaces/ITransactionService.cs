using payFlow.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace payFlow.Core.Interfaces
{
    public interface ITransactionService
    {
        Task ProcessTransactionAsync(int userId, string title, decimal amount, ETransactionType type, long categoryId);
    }
}
