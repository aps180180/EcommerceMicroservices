using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Services.ShoppingCartAPI.Models.Mappings
{
    public class CartHeaderMap : IEntityTypeConfiguration<CartHeader>
    {
        public void Configure(EntityTypeBuilder<CartHeader> builder)
        {
            builder.ToTable("CartHeader");
            builder.HasKey(x => x.CartHeaderId);

            builder.Property(x => x.UserId)
                   .HasColumnName("UserId")
                   .HasColumnType("NVARCHAR")
                   .HasMaxLength(150)
                   .IsRequired(false);

            builder.Property(x => x.CouponCode)
                   .HasColumnName("CouponCode")
                   .HasColumnType("NVARCHAR")
                   .HasMaxLength(20)
                   .IsRequired(false);

            

        }
    }
}
