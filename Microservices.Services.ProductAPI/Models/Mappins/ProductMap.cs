using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microservices.Services.ProductAPI.Models.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(x => x.ProductId);  
            
            builder.Property(x=> x.Name)
                   .HasColumnName("Name")
                   .HasColumnType("NVARCHAR")
                   .HasMaxLength(150)
                   .IsRequired(true);
            
            builder.Property(x => x.Price)
                   .HasColumnName("Price")
                   .HasColumnType("Decimal(18,2)")
                   .IsRequired(true);

            builder.Property(x => x.Description)
                   .HasColumnName("Description")
                   .HasColumnType("NVARCHAR")
                   .HasMaxLength(250);
            
            builder.Property(x => x.CategoryName)
                   .HasColumnName("CategoryName")
                   .HasColumnType("NVARCHAR")
                   .HasMaxLength(100);

            builder.Property(x => x.ImageUrl)
                   .HasColumnName("ImageUrl")
                   .HasColumnType("NVARCHAR")
                   .HasMaxLength(255);



        }
    }
}
