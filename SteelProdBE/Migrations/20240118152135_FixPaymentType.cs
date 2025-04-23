using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SteelProdBE.Migrations
{
    /// <inheritdoc />
    public partial class FixPaymentType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalPayment",
                table: "PaymentTypes");

            migrationBuilder.DropColumn(
                name: "AdditionalPaymentFollowingMonth",
                table: "PaymentTypes");

            migrationBuilder.DropColumn(
                name: "FifthPayment",
                table: "PaymentTypes");

            migrationBuilder.DropColumn(
                name: "FirstPayment",
                table: "PaymentTypes");

            migrationBuilder.DropColumn(
                name: "FourthPayment",
                table: "PaymentTypes");

            migrationBuilder.DropColumn(
                name: "InvoiceDate",
                table: "PaymentTypes");

            migrationBuilder.DropColumn(
                name: "SecondPayment",
                table: "PaymentTypes");

            migrationBuilder.DropColumn(
                name: "ThirdPayment",
                table: "PaymentTypes");

            migrationBuilder.DropColumn(
                name: "TotalPayments",
                table: "PaymentTypes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdditionalPayment",
                table: "PaymentTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "AdditionalPaymentFollowingMonth",
                table: "PaymentTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "FifthPayment",
                table: "PaymentTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FirstPayment",
                table: "PaymentTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FourthPayment",
                table: "PaymentTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "InvoiceDate",
                table: "PaymentTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SecondPayment",
                table: "PaymentTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ThirdPayment",
                table: "PaymentTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalPayments",
                table: "PaymentTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
