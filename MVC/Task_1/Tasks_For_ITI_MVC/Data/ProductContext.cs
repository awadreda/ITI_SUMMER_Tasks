
using Microsoft.EntityFrameworkCore;
using Tasks_For_ITI_MVC.Models;

namespace Tasks_For_ITI_MVC.Data;





public class ProductContext : DbContext
{
  public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

  
  public DbSet<Product> Products { get; set; }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    base.OnModelCreating(builder);

     builder.Entity<Product>()
        .Property(p => p.Price)
        .HasPrecision(18, 2);


    builder.Entity<Product>().HasData(
      new Product
            {
                Id = 1,
                Name = "Laptop",
                Price = 15000,
                ImageUrl = "/images/laptop.jpg",
                Description = "A powerful laptop for work and gaming."
            },
            new Product
            {
                Id = 2,
                Name = "Smartphone",
                Price = 8000,
                ImageUrl = "/images/phone.jpg",
                Description = "A modern smartphone with high-quality camera."
            },
            new Product
            {
                Id = 3,
                Name = "Headphones",
                Price = 1200,
                ImageUrl = "/images/headphones.jpg",
                Description = "Wireless headphones with noise cancellation."
            });     
    
  }
}