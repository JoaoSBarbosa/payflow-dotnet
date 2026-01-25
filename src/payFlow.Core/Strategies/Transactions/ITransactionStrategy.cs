namespace payFlow.Core.Strategies.Transactions
{
    public interface ITransactionStrategy
    {
        decimal Apply(decimal currentBalance, decimal amount);
    }
}
