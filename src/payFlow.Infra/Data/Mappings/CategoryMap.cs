using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using payFlow.Core.Models;

namespace payFlow.Infra.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");

            builder.HasKey(c => c.Id);

            builder.Property( c => c.Title)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);

            builder.Property( c => c.Description)
                .IsRequired(false)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255);

            builder.Property(c => c.UserId)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(200);

            builder.Property(c => c.CreatedAt)
                .IsRequired()
                .HasColumnType("DATETIME2")
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
