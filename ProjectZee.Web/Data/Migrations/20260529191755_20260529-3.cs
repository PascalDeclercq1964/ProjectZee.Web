using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectZee.Web.Migrations
{
    /// <inheritdoc />
    public partial class _202605293 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectShareholder_ShareHolder_ShareholderId",
                table: "ProjectShareholder");

            migrationBuilder.DropIndex(
                name: "IX_ProjectShareholder_ShareholderId",
                table: "ProjectShareholder");

            migrationBuilder.DropColumn(
                name: "ShareholderId",
                table: "ProjectShareholder");

            migrationBuilder.DropColumn(
                name: "ShareholderProjectStatusId",
                table: "ProjectShareholder");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ProjectShareholder",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectShareholder_UserId",
                table: "ProjectShareholder",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectShareholder_AspNetUsers_UserId",
                table: "ProjectShareholder",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectShareholder_AspNetUsers_UserId",
                table: "ProjectShareholder");

            migrationBuilder.DropIndex(
                name: "IX_ProjectShareholder_UserId",
                table: "ProjectShareholder");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ProjectShareholder");

            migrationBuilder.AddColumn<int>(
                name: "ShareholderId",
                table: "ProjectShareholder",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShareholderProjectStatusId",
                table: "ProjectShareholder",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectShareholder_ShareholderId",
                table: "ProjectShareholder",
                column: "ShareholderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectShareholder_ShareHolder_ShareholderId",
                table: "ProjectShareholder",
                column: "ShareholderId",
                principalTable: "ShareHolder",
                principalColumn: "ShareHolderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
