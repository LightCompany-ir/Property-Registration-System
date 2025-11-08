using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class chnge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PropertyColor",
                table: "Properties",
                newName: "OldPropertyNumber");

            migrationBuilder.RenameColumn(
                name: "PropertyBrand",
                table: "Properties",
                newName: "NewPropertyNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OldPropertyNumber",
                table: "Properties",
                newName: "PropertyColor");

            migrationBuilder.RenameColumn(
                name: "NewPropertyNumber",
                table: "Properties",
                newName: "PropertyBrand");
        }
    }
}
