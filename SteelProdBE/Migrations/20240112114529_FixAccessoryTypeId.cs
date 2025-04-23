using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SteelProdBE.Migrations
{
    /// <inheritdoc />
    public partial class FixAccessoryTypeId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accessories_AccessoryTypes_AccessoryTypeId",
                table: "Accessories");

            migrationBuilder.DropColumn(
                name: "IdAccessoryType",
                table: "Accessories");

            migrationBuilder.AlterColumn<int>(
                name: "AccessoryTypeId",
                table: "Accessories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Accessories_AccessoryTypes_AccessoryTypeId",
                table: "Accessories",
                column: "AccessoryTypeId",
                principalTable: "AccessoryTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accessories_AccessoryTypes_AccessoryTypeId",
                table: "Accessories");

            migrationBuilder.AlterColumn<int>(
                name: "AccessoryTypeId",
                table: "Accessories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdAccessoryType",
                table: "Accessories",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Accessories_AccessoryTypes_AccessoryTypeId",
                table: "Accessories",
                column: "AccessoryTypeId",
                principalTable: "AccessoryTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
