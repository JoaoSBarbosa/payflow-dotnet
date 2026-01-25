using Microsoft.EntityFrameworkCore;
using payFlow.Core.Models;

namespace payFlow.Infra.Data
{
    public class PayFlowContext: DbContext
    {
        public PayFlowContext(DbContextOptionsBuilder<PayFlowContext> optionsBuilder) : base() { }

        public DbSet<Category> Categories => Set<Category>();
    }
}
