using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using InvoiceSystem.Entities;

namespace InvoiceSystem.DataLayer.Mappings
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(product => product.Name).HasMaxLength(450).IsRequired();
            builder.HasOne(product => product.Category)
                   .WithMany(category => category.Products);
        }
    }
}