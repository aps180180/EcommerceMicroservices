using Microservices.Services.ShoppingCartAPI.Models;
using Microservices.Services.ShoppingCartAPI.Models.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Services.ShoppingCartAPI.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext( DbContextOptions<AppDbContext> options): base(options)
        {
                
        }
        public DbSet<CartHeader> CartHeaders { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CartHeaderMap());
            modelBuilder.ApplyConfiguration(new CartDetailsMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
