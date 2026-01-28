using Microsoft.EntityFrameworkCore;
using payFlow.Core.Models;
using System.Reflection;

namespace payFlow.Infra.Data.Context
{
    public class PayFlowContext(DbContextOptions<PayFlowContext> optionsBuilder) : DbContext(optionsBuilder)
    {
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Transaction> Transactions => Set<Transaction>();
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // vai varrer o dll procurando todas as classes que implementam IEntityTypeConfiguration<T> e aplicar as configurações
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
