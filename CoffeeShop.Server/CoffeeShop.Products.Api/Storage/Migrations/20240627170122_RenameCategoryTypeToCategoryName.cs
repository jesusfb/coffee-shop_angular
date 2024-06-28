using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeShop.Products.Api.Storage.Migrations
{
    /// <inheritdoc />
    public partial class RenameCategoryTypeToCategoryName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryType",
                table: "Products",
                newName: "CategoryName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Products",
                newName: "CategoryType");
        }
    }
}
