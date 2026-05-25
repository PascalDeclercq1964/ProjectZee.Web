using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectZee.Web.Migrations
{
    /// <inheritdoc />
    public partial class firsttables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomAttribute",
                columns: table => new
                {
                    CustomAttributeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomAttribute", x => x.CustomAttributeId);
                });

            migrationBuilder.CreateTable(
                name: "ShareHolder",
                columns: table => new
                {
                    ShareHolderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasPartner = table.Column<bool>(type: "bit", nullable: false),
                    PartnerFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartnerLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartnerBirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TargetBudget = table.Column<double>(type: "float", nullable: false),
                    MaxBudget = table.Column<double>(type: "float", nullable: false),
                    PreferredRegion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreferredBedrooms = table.Column<int>(type: "int", nullable: false),
                    MaxDistanceToBeach = table.Column<int>(type: "int", nullable: false),
                    SeaViewPreference = table.Column<int>(type: "int", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShareHolder", x => x.ShareHolderId);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionOrCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TargetBudget = table.Column<double>(type: "float", nullable: false),
                    Bedrooms = table.Column<int>(type: "int", nullable: false),
                    MinApartmentSize = table.Column<int>(type: "int", nullable: false),
                    MaxDistanceToBeach = table.Column<int>(type: "int", nullable: false),
                    SeaView = table.Column<int>(type: "int", nullable: false),
                    TerrasRequirement = table.Column<int>(type: "int", nullable: false),
                    MinTerrasSize = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ShareHolderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Project_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Project_ShareHolder_ShareHolderId",
                        column: x => x.ShareHolderId,
                        principalTable: "ShareHolder",
                        principalColumn: "ShareHolderId");
                });

            migrationBuilder.CreateTable(
                name: "CustomAttributeValue",
                columns: table => new
                {
                    CustomAttributeValueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomAttributeId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomAttributeValue", x => x.CustomAttributeValueId);
                    table.ForeignKey(
                        name: "FK_CustomAttributeValue_CustomAttribute_CustomAttributeId",
                        column: x => x.CustomAttributeId,
                        principalTable: "CustomAttribute",
                        principalColumn: "CustomAttributeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomAttributeValue_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectFollower",
                columns: table => new
                {
                    ProjectFollowerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectFollower", x => x.ProjectFollowerId);
                    table.ForeignKey(
                        name: "FK_ProjectFollower_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectFollower_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectShareholder",
                columns: table => new
                {
                    ProjectShareholderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShareholderId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ShareholderProjectStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectShareholder", x => x.ProjectShareholderId);
                    table.ForeignKey(
                        name: "FK_ProjectShareholder_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectShareholder_ShareHolder_ShareholderId",
                        column: x => x.ShareholderId,
                        principalTable: "ShareHolder",
                        principalColumn: "ShareHolderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomAttributeValue_CustomAttributeId",
                table: "CustomAttributeValue",
                column: "CustomAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomAttributeValue_ProjectId",
                table: "CustomAttributeValue",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ApplicationUserId",
                table: "Project",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ShareHolderId",
                table: "Project",
                column: "ShareHolderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFollower_ProjectId",
                table: "ProjectFollower",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFollower_UserId",
                table: "ProjectFollower",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectShareholder_ProjectId",
                table: "ProjectShareholder",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectShareholder_ShareholderId",
                table: "ProjectShareholder",
                column: "ShareholderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomAttributeValue");

            migrationBuilder.DropTable(
                name: "ProjectFollower");

            migrationBuilder.DropTable(
                name: "ProjectShareholder");

            migrationBuilder.DropTable(
                name: "CustomAttribute");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "ShareHolder");
        }
    }
}
