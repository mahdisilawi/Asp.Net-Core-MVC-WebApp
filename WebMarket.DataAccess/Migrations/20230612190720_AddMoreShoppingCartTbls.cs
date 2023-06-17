using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebMarket.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreShoppingCartTbls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "ShoppingCarts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "ShoppingCarts");
        }
    }
}
