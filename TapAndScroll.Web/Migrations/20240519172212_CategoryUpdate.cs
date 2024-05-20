using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TapAndScroll.Web.Migrations
{
    /// <inheritdoc />
    public partial class CategoryUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Page",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalParameters",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Page",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AdditionalParameters",
                table: "Categories");
        }
    }
}
