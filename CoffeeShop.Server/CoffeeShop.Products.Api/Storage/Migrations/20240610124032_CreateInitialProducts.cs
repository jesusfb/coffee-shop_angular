using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoffeeShop.Products.Api.Storage.Migrations
{
    /// <inheritdoc />
    public partial class CreateInitialProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ProductRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stars = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductRatings_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "City", "CreatedAt", "Name", "State", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Seattle", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Best Beans", "WA", null },
                    { 2, "San Francisco", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Coffee Palace", "CA", null },
                    { 3, "New York", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Java Central", "NY", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "CreatedAt", "Description", "Name", "Price", "SupplierId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "WholeBean", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rich and aromatic Ethiopian beans.", "Ethiopian Whole Bean", 15.99m, 1, null },
                    { 2, "Ground", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smooth and strong Italian ground coffee.", "Italian Ground Coffee", 12.50m, 2, null },
                    { 3, "Instant", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Convenient and tasty instant coffee.", "Instant Coffee Delight", 8.99m, 3, null },
                    { 4, "Pods", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rich espresso coffee pods.", "Espresso Coffee Pods", 9.99m, 1, null },
                    { 5, "CoffeeMakers", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eco-friendly coffee maker.", "Organic Coffee Maker", 55.00m, 2, null },
                    { 6, "Subscriptions", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Receive a new coffee each month.", "Monthly Coffee Subscription", 29.99m, 1, null },
                    { 7, "Subscriptions", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Premium coffee delivered monthly.", "Premium Coffee Subscription", 49.99m, 2, null },
                    { 8, "Subscriptions", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Exclusive blends for coffee lovers.", "Coffee Lover's Subscription", 39.99m, 3, null }
                });

            migrationBuilder.InsertData(
                table: "ProductRatings",
                columns: new[] { "Id", "CreatedAt", "ProductId", "Stars", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5, null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, null },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 5, null },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 4, null },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 5, null },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 4, null },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 5, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductRatings_ProductId",
                table: "ProductRatings",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierId",
                table: "Products",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductRatings");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
