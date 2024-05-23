using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TapAndScroll.Web.Migrations
{
    /// <inheritdoc />
    public partial class APC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalParameters",
                table: "Categories");

            migrationBuilder.CreateTable(
                name: "AdditionalParametersCategory",
                columns: table => new
                {
                    IdAdditionalParameters = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    NameParameters = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SlugParameters = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalParametersCategory", x => x.IdAdditionalParameters);
                    table.ForeignKey(
                        name: "FK_AdditionalParametersCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "IdCategory",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalParametersCategory_CategoryId",
                table: "AdditionalParametersCategory",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalParametersCategory");

            migrationBuilder.AddColumn<string>(
                name: "AdditionalParameters",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
