using payFlow.Core.Enums;
using payFlow.Core.Models.Base;

namespace payFlow.Core.Models
{
    public class Transaction: BaseEntity
    {
        public DateTime? PaidOrReceivedAt { get; set; }
        public ETransactionType Type { get; set; } = ETransactionType.Withdraw;
        public Decimal Amount { get; set; }
        public long CategoryId { get; private set; }
        public Category Category { get; set; } = null!;


        public string UserId { get; set; } = string.Empty;
    }
}
