using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    CartId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "CustomerId" },
                values: new object[,]
                {
                    { 1, 101 },
                    { 2, 102 },
                    { 3, 103 }
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

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "Id", "CartId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 2 },
                    { 2, 1, 3, 1 },
                    { 3, 2, 6, 1 },
                    { 4, 2, 8, 3 },
                    { 5, 3, 5, 2 },
                    { 6, 3, 10, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
