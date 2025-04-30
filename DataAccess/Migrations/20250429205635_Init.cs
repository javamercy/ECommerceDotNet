using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Stock = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "Status", "Stock" },
                values: new object[,]
                {
                    { 1, "Apple's flagship iPhone with A17 Pro chip, titanium design, and 48MP camera", "https://picsum.photos/200", "iPhone 15 Pro Max", 1199.99m, true, 75 },
                    { 2, "Premium iPhone with A17 Pro chip, Action button, and titanium design", "https://picsum.photos/200", "iPhone 15 Pro", 999.99m, true, 85 },
                    { 3, "Latest standard iPhone with A16 Bionic chip and Dynamic Island", "https://picsum.photos/200", "iPhone 15", 799.99m, true, 90 },
                    { 4, "Previous generation premium iPhone with A16 Bionic chip and Dynamic Island", "https://picsum.photos/200", "iPhone 14 Pro", 899.99m, true, 65 },
                    { 5, "Compact iPhone with A15 Bionic chip and Touch ID", "https://picsum.photos/200", "iPhone SE (2022)", 429.99m, true, 100 },
                    { 6, "Samsung's flagship with Snapdragon 8 Gen 3, S Pen, and AI features", "https://picsum.photos/200", "Samsung Galaxy S24 Ultra", 1299.99m, true, 55 },
                    { 7, "Large display Galaxy with Snapdragon 8 Gen 3 and advanced camera system", "https://picsum.photos/200", "Samsung Galaxy S24+", 999.99m, true, 60 },
                    { 8, "Standard Galaxy S series with powerful performance and AI features", "https://picsum.photos/200", "Samsung Galaxy S24", 799.99m, true, 70 },
                    { 9, "Previous generation Ultra with Snapdragon 8 Gen 2 and 200MP camera", "https://picsum.photos/200", "Samsung Galaxy S23 Ultra", 1099.99m, true, 50 },
                    { 10, "Previous generation S series with excellent camera and performance", "https://picsum.photos/200", "Samsung Galaxy S23", 699.99m, true, 65 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
