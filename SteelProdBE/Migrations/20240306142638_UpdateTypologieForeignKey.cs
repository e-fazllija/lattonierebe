using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SteelProdBE.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTypologieForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_DeliveryTypes_DeliveryMethodId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DeliveryMethodId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "DeliveryMethodId",
                table: "Materials");

            migrationBuilder.RenameColumn(
                name: "DeliveryMethodId",
                table: "Customers",
                newName: "DeliveryTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_DeliveryMethodId",
                table: "Customers",
                newName: "IX_Customers_DeliveryTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_DeliveryTypes_DeliveryTypeId",
                table: "Customers",
                column: "DeliveryTypeId",
                principalTable: "DeliveryTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_DeliveryTypes_DeliveryTypeId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "DeliveryTypeId",
                table: "Customers",
                newName: "DeliveryMethodId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_DeliveryTypeId",
                table: "Customers",
                newName: "IX_Customers_DeliveryMethodId");

            migrationBuilder.AddColumn<int>(
                name: "DeliveryMethodId",
                table: "Profiles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryMethodId",
                table: "Materials",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_DeliveryTypes_DeliveryMethodId",
                table: "Customers",
                column: "DeliveryMethodId",
                principalTable: "DeliveryTypes",
                principalColumn: "Id");
        }
    }
}
