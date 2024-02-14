using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microservices.Services.CupomAPI.Models.Mappings
{
    public class CouponMap : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.ToTable("Coupon");
            builder.HasKey(x => x.CouponId);  
            
            builder.Property(x=> x.CouponCode)
                   .HasColumnName("CouponCode")
                   .HasColumnType("NVARCHAR")
                   .HasMaxLength(20)
                   .IsRequired(true);
            
            builder.Property(x => x.DiscountAmount)
                   .HasColumnName("DiscountAmount")
                   .HasColumnType("Decimal(18,2)")
                   .IsRequired(true);

            builder.Property(x => x.MinAmount)
                   .HasColumnName("MinAmount")
                   .HasColumnType("int");


            builder.Property(x => x.LastUpdated)
                   .HasColumnName("LastUpdated")
                   .HasColumnType("Datetime")
                   .IsRequired(false);
                  

        }
    }
}
