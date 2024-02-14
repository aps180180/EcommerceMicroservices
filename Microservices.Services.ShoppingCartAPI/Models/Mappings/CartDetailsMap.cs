using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Services.ShoppingCartAPI.Models.Mappings
{
    public class CartDetailsMap : IEntityTypeConfiguration<CartDetails>
    {
        public void Configure(EntityTypeBuilder<CartDetails> builder)
        {
            builder.HasKey(cd => cd.CartDetailsId);

            builder.Property(cd => cd.CartDetailsId)
                .IsRequired();

            builder.Property(cd => cd.CartHeaderId)
                .IsRequired();

            builder.HasOne(cd => cd.CartHeader)
                .WithMany(ch => ch.CartDetails)
                .HasForeignKey(cd => cd.CartHeaderId)
                .IsRequired();

            builder.Property(cd => cd.ProductId)
                .IsRequired();

            builder.Ignore(cd => cd.Product);

            builder.Property(cd => cd.Count)
                .IsRequired();



        }
    }
}
