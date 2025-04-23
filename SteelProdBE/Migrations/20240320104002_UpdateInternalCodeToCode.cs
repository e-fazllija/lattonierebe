using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SteelProdBE.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInternalCodeToCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InternalCode",
                table: "Materials",
                newName: "Code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Materials",
                newName: "InternalCode");
        }
    }
}
