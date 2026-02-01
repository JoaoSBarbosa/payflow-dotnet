using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using payFlow.Core.Models;

namespace payFlow.Infra.Data.Mappings
{
    public class TransactionMap : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {

            builder.ToTable("Transaction");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Title)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(120);

            builder.Property( t => t.Type)
                .HasColumnType("SMALLINT");

            builder.Property( t => t.Amount)
                .IsRequired()
                .HasColumnType("MONEY");

            builder.Property( t => t.CreatedAt)
                .IsRequired()
                .HasColumnType("DATETIME2")
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(t => t.PaidOrReceivedAt)
                .IsRequired(false)
                .HasColumnType("DATETIME2");

            //email do usuario que realizou a transação
            builder.Property(t => t.UserId)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(200);

            builder.HasOne( t => t.Category)
                .WithMany( c => c.Transactions)
                .HasForeignKey( t => t.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
