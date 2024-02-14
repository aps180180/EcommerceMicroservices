using Microservices.Services.CupomAPI.Models;
using Microservices.Services.CupomAPI.Models.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Services.CupomAPI.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext( DbContextOptions<AppDbContext> options): base(options)
        {
                
        }
        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CouponMap());

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId =1,
                CouponCode = "10OFF",
                DiscountAmount = 10,
                MinAmount = 20

            });
            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 2,
                CouponCode = "20OFF",
                DiscountAmount = 20,
                MinAmount = 20

            });
            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 3,
                CouponCode = "40OFF",
                DiscountAmount = 40,
                MinAmount = 40

            });
        }
    }
}
