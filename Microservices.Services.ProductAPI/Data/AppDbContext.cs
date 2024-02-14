using Microservices.Services.ProductAPI.Models;
using Microservices.Services.ProductAPI.Models.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Services.ProductAPI.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext( DbContextOptions<AppDbContext> options): base(options)
        {
                
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                Name = "Notebok Lenovo E14 3Gnd",
                Price = 4560.00M,
                Description = "O notebook Lenovo E14 3Gn combina desempenho potente e design elegante. Equipado com recursos avançados, como processador eficiente e tela nítida de 14 polegadas",
                ImageUrl = "https://placehold.co/603x403",
                CategoryName = "Laptops"
            }) ;
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                Name = "Notebook Dell inspirion 1560",
                Price = 5760.99M,
                Description = " O notebook Dell Inspiron 1560 é uma fusão de estilo e eficiência. Com tela de 15,6 polegadas, processador poderoso e design moderno.",
                ImageUrl = "https://placehold.co/602x402",
                CategoryName = "Laptops"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                Name = "SSD NVMe 512 Gb Samsung",
                Price = 710.99M,
                Description = " O SSD NVMe Samsung de 512 GB redefine a velocidade e a eficiência do armazenamento. Com tecnologia avançada, oferece desempenho excepcional.",
                ImageUrl = "https://placehold.co/601x401",
                CategoryName = "Dispositivos de Mémoria"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 4,
                Name = "Memória DDR5 Kingston 32Gb",
                Price = 754.15M,
                Description = " A memória DDR5 Kingston de 32 GB é a escolha definitiva para desempenho excepcional em computação.",
                ImageUrl = "https://placehold.co/600x400",
                CategoryName = "Dispositivos de Mémoria"
            });

        }
    }
}
