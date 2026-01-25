namespace payFlow.Core.Strategies.Transactions
{
    public class IncomeTransactionStrategy : ITransactionStrategy
    {
        public decimal Apply(decimal currentBalance, decimal amount)
        {
           return currentBalance + amount;
        }
    }
}
