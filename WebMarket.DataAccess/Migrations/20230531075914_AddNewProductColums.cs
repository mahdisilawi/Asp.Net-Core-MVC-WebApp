using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebMarket.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddNewProductColums : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImegUrl",
                table: "Products",
                newName: "ShortDescription");

            migrationBuilder.AddColumn<string>(
                name: "ImageAlt",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageTitle",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageAlt",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImageTitle",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ShortDescription",
                table: "Products",
                newName: "ImegUrl");
        }
    }
}
