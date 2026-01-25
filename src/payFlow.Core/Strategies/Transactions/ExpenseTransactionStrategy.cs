namespace payFlow.Core.Strategies.Transactions
{
    internal class ExpenseTransactionStrategy : ITransactionStrategy
    {
        public decimal Apply(decimal currentBalance, decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("O valor da despesa deve ser maior que zero.", nameof(amount));
            return currentBalance - amount;
        }
    }
}
