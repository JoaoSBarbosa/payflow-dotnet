using Microsoft.EntityFrameworkCore;
using payFlow.Core.Models;

namespace payFlow.Infra.Data
{
    public class PayFlowContext: DbContext
    {
        public PayFlowContext(DbContextOptions<PayFlowContext> optionsBuilder) : base(optionsBuilder) { }

        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Transaction> Transactions => Set<Transaction>();


        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PayFlowContext).Assembly);
        }
}
