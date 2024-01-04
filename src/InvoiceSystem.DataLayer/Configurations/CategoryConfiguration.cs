using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using InvoiceSystem.Entities;

namespace InvoiceSystem.DataLayer.Mappings
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(category => category.Name).HasMaxLength(450).IsRequired();
            builder.Property(category => category.Title).IsRequired();
        }
    }
}