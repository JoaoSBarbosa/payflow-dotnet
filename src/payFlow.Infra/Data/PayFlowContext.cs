using Microsoft.EntityFrameworkCore;
using payFlow.Core.Models;
using System.Reflection;

namespace payFlow.Infra.Data
{
    public class PayFlowContext : DbContext
    {
        public PayFlowContext(DbContextOptions<PayFlowContext> optionsBuilder) : base(optionsBuilder) { }

        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Transaction> Transactions => Set<Transaction>();


        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            // vai varrer o dll procurando todas as classes que implementam IEntityTypeConfiguration<T> e aplicar as configurações
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
