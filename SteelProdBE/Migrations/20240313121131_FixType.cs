using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SteelProdBE.Migrations
{
    /// <inheritdoc />
    public partial class FixType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_PaymentTypes_PaymentMethodId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "PaymentMethodId",
                table: "Customers",
                newName: "PaymentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_PaymentMethodId",
                table: "Customers",
                newName: "IX_Customers_PaymentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_PaymentTypes_PaymentTypeId",
                table: "Customers",
                column: "PaymentTypeId",
                principalTable: "PaymentTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_PaymentTypes_PaymentTypeId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "PaymentTypeId",
                table: "Customers",
                newName: "PaymentMethodId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_PaymentTypeId",
                table: "Customers",
                newName: "IX_Customers_PaymentMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_PaymentTypes_PaymentMethodId",
                table: "Customers",
                column: "PaymentMethodId",
                principalTable: "PaymentTypes",
                principalColumn: "Id");
        }
    }
}
