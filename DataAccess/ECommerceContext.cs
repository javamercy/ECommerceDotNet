using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess
{
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
                        "https://picsum.photos/200", 75, true),
                    new(2, "iPhone 15 Pro", "Premium iPhone with A17 Pro chip, Action button, and titanium design",
                        999.99m, "https://picsum.photos/200", 85, true),
                    new(3, "iPhone 15", "Latest standard iPhone with A16 Bionic chip and Dynamic Island", 799.99m,
                        "https://picsum.photos/200", 90, true),
                    new(4, "iPhone 14 Pro",
                        "Previous generation premium iPhone with A16 Bionic chip and Dynamic Island", 899.99m,
                        "https://picsum.photos/200", 65, true),
                    new(5, "iPhone SE (2022)", "Compact iPhone with A15 Bionic chip and Touch ID", 429.99m,
                        "https://picsum.photos/200", 100, true),
                    new(6, "Samsung Galaxy S24 Ultra",
                        "Samsung's flagship with Snapdragon 8 Gen 3, S Pen, and AI features", 1299.99m,
                        "https://picsum.photos/200", 55, true),
                    new(7, "Samsung Galaxy S24+",
                        "Large display Galaxy with Snapdragon 8 Gen 3 and advanced camera system", 999.99m,
                        "https://picsum.photos/200", 60, true),
                    new(8, "Samsung Galaxy S24", "Standard Galaxy S series with powerful performance and AI features",
                        799.99m, "https://picsum.photos/200", 70, true),
                    new(9, "Samsung Galaxy S23 Ultra",
                        "Previous generation Ultra with Snapdragon 8 Gen 2 and 200MP camera", 1099.99m,
                        "https://picsum.photos/200", 50, true),
                    new(10, "Samsung Galaxy S23", "Previous generation S series with excellent camera and performance",
                        699.99m, "https://picsum.photos/200", 65, true)
                }
            );
        }
    }
}