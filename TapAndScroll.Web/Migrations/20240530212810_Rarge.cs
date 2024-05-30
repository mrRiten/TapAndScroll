using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TapAndScroll.Web.Migrations
{
    /// <inheritdoc />
    public partial class Rarge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRange",
                table: "AdditionalParametersCategory",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRange",
                table: "AdditionalParametersCategory");
        }
    }
}
