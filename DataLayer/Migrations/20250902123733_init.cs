using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    PlaceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaceName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PlaceDescription = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.PlaceId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    AdminUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.AdminUserId);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PropertyBrand = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PropertyColor = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PropertyDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PlaceId = table.Column<int>(type: "int", nullable: false),
                    CreatedByUser = table.Column<int>(type: "int", nullable: false),
                    UpdatedByUser = table.Column<int>(type: "int", nullable: false),
                    DeletedByUser = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.PropertyId);
                    table.ForeignKey(
                        name: "FK_Properties_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AdminUserId", "FullName", "IsActive", "Password", "Phone", "RegisterDate", "UserImage", "UserName" },
                values: new object[] { 1, "میلاد اسدی", true, "123456789", "09116430304", new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Default.png", "lightco" });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_PlaceId",
                table: "Properties",
                column: "PlaceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Places");
        }
    }
}
