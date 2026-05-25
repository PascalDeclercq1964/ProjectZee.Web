using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectZee.Web.Migrations
{
    /// <inheritdoc />
    public partial class _202605251 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShareCount",
                table: "ProjectShareholder",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShareCount",
                table: "ProjectShareholder");
        }
    }
}
