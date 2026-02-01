using payFlow.Core.Enums;
using payFlow.Core.Strategies.Transactions;

namespace payFlow.Core.Factories
{
    public static class TransactionStrategyFactory
    {
        public static ITransactionStrategy Create(ETransactionType type)
        {
            return type switch
            {
                ETransactionType.Deposit => new IncomeTransactionStrategy(),
                ETransactionType.Withdraw => new ExpenseTransactionStrategy(),
                _ => throw new NotSupportedException($"Transação do tipo '{type}' não é suportada.")
            };
        }
    }
}
