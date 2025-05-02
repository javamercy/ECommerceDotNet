using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess;

public class ECommerceContext : DbContext
{
    public ECommerceContext(DbContextOptions<ECommerceContext> options, IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public ECommerceContext()
    {
    }

    public DbSet<Product> Products { get; set; }

    public DbSet<Cart> Carts { get; set; }

    public DbSet<CartItem> CartItems { get; set; }
    public IConfiguration Configuration { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(Configuration.GetConnectionString("ECommerceDb"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>().HasData(
            new List<Product>
            {
                new(1, "iPhone 15 Pro Max",
                    "Apple's flagship iPhone with A17 Pro chip, titanium design, and 48MP camera", 1199.99m,
                    "1.jpg", 75, true),
                new(2, "iPhone 15 Pro", "Premium iPhone with A17 Pro chip, Action button, and titanium design",
                    999.99m, "1.jpg", 85, true),
                new(3, "iPhone 15", "Latest standard iPhone with A16 Bionic chip and Dynamic Island", 799.99m,
                    "1.jpg", 90, true),
                new(4, "iPhone 14 Pro",
                    "Previous generation premium iPhone with A16 Bionic chip and Dynamic Island", 899.99m,
                    "1.jpg", 65, true),
                new(5, "iPhone SE (2022)", "Compact iPhone with A15 Bionic chip and Touch ID", 429.99m,
                    "1.jpg", 100, true),
                new(6, "Samsung Galaxy S24 Ultra",
                    "Samsung's flagship with Snapdragon 8 Gen 3, S Pen, and AI features", 1299.99m,
                    "1.jpg", 55, true),
                new(7, "Samsung Galaxy S24+",
                    "Large display Galaxy with Snapdragon 8 Gen 3 and advanced camera system", 999.99m,
                    "1.jpg", 60, true),
                new(8, "Samsung Galaxy S24", "Standard Galaxy S series with powerful performance and AI features",
                    799.99m, "1.jpg", 70, true),
                new(9, "Samsung Galaxy S23 Ultra",
                    "Previous generation Ultra with Snapdragon 8 Gen 2 and 200MP camera", 1099.99m,
                    "1.jpg", 50, true),
                new(10, "Samsung Galaxy S23", "Previous generation S series with excellent camera and performance",
                    699.99m, "1.jpg", 65, true)
            }
        );

        modelBuilder.Entity<Cart>().HasData(
            new Cart { Id = 1, CustomerId = 101 },
            new Cart { Id = 2, CustomerId = 102 },
            new Cart { Id = 3, CustomerId = 103 }
        );

        modelBuilder.Entity<CartItem>().HasData(
            new CartItem { Id = 1, CartId = 1, ProductId = 1, Quantity = 2 },
            new CartItem { Id = 2, CartId = 1, ProductId = 3, Quantity = 1 },
            new CartItem { Id = 3, CartId = 2, ProductId = 6, Quantity = 1 },
            new CartItem { Id = 4, CartId = 2, ProductId = 8, Quantity = 3 },
            new CartItem { Id = 5, CartId = 3, ProductId = 5, Quantity = 2 },
            new CartItem { Id = 6, CartId = 3, ProductId = 10, Quantity = 1 }
        );
    }
}