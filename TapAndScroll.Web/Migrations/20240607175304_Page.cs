using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TapAndScroll.Web.Migrations
{
    /// <inheritdoc />
    public partial class Page : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Page",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Page",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
