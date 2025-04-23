using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SteelProdBE.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DDTGenerato",
                table: "XmlOpera");

            migrationBuilder.DropColumn(
                name: "DataAccreditoAcconto",
                table: "XmlOpera");

            migrationBuilder.DropColumn(
                name: "DataApprontamentoMerce",
                table: "XmlOpera");

            migrationBuilder.DropColumn(
                name: "Errore",
                table: "XmlOpera");

            migrationBuilder.DropColumn(
                name: "FAccontoGenerata",
                table: "XmlOpera");

            migrationBuilder.DropColumn(
                name: "FatturaGenerata",
                table: "XmlOpera");

            migrationBuilder.DropColumn(
                name: "FileAccessori",
                table: "XmlOpera");

            migrationBuilder.DropColumn(
                name: "FileCommessa",
                table: "XmlOpera");

            migrationBuilder.DropColumn(
                name: "FileOrdine",
                table: "XmlOpera");

            migrationBuilder.DropColumn(
                name: "IdTipologiaCommessa",
                table: "XmlOpera");

            migrationBuilder.DropColumn(
                name: "MercePronta",
                table: "XmlOpera");

            migrationBuilder.DropColumn(
                name: "PercentualeFAcconto",
                table: "XmlOpera");

            migrationBuilder.DropColumn(
                name: "Reso",
                table: "XmlOpera");

            migrationBuilder.DropColumn(
                name: "Stato",
                table: "XmlOpera");

            migrationBuilder.RenameColumn(
                name: "TotaleFAcconto",
                table: "XmlOpera",
                newName: "State");

            migrationBuilder.AddColumn<int>(
                name: "DeliveryTypeId",
                table: "Profiles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryTypeId",
                table: "Materials",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_DeliveryTypeId",
                table: "Profiles",
                column: "DeliveryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_MaterialTypeId",
                table: "Profiles",
                column: "MaterialTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_ProfileTypeId",
                table: "Profiles",
                column: "ProfileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_SupplierId",
                table: "Profiles",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_DeliveryTypeId",
                table: "Materials",
                column: "DeliveryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerTypeId",
                table: "Customers",
                column: "CustomerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_DeliveryMethodId",
                table: "Customers",
                column: "DeliveryMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PaymentMethodId",
                table: "Customers",
                column: "PaymentMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomerTypes_CustomerTypeId",
                table: "Customers",
                column: "CustomerTypeId",
                principalTable: "CustomerTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_DeliveryTypes_DeliveryMethodId",
                table: "Customers",
                column: "DeliveryMethodId",
                principalTable: "DeliveryTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_PaymentTypes_PaymentMethodId",
                table: "Customers",
                column: "PaymentMethodId",
                principalTable: "PaymentTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_DeliveryTypes_DeliveryTypeId",
                table: "Materials",
                column: "DeliveryTypeId",
                principalTable: "DeliveryTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_DeliveryTypes_DeliveryTypeId",
                table: "Profiles",
                column: "DeliveryTypeId",
                principalTable: "DeliveryTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_MaterialTypes_MaterialTypeId",
                table: "Profiles",
                column: "MaterialTypeId",
                principalTable: "MaterialTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_ProfileTypes_ProfileTypeId",
                table: "Profiles",
                column: "ProfileTypeId",
                principalTable: "ProfileTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Suppliers_SupplierId",
                table: "Profiles",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomerTypes_CustomerTypeId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_DeliveryTypes_DeliveryMethodId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_PaymentTypes_PaymentMethodId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_DeliveryTypes_DeliveryTypeId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_DeliveryTypes_DeliveryTypeId",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_MaterialTypes_MaterialTypeId",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_ProfileTypes_ProfileTypeId",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Suppliers_SupplierId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_DeliveryTypeId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_MaterialTypeId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_ProfileTypeId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_SupplierId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Materials_DeliveryTypeId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CustomerTypeId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_DeliveryMethodId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_PaymentMethodId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DeliveryTypeId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "DeliveryTypeId",
                table: "Materials");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "XmlOpera",
                newName: "TotaleFAcconto");

            migrationBuilder.AddColumn<bool>(
                name: "DDTGenerato",
                table: "XmlOpera",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAccreditoAcconto",
                table: "XmlOpera",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataApprontamentoMerce",
                table: "XmlOpera",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Errore",
                table: "XmlOpera",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FAccontoGenerata",
                table: "XmlOpera",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FatturaGenerata",
                table: "XmlOpera",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "FileAccessori",
                table: "XmlOpera",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileCommessa",
                table: "XmlOpera",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileOrdine",
                table: "XmlOpera",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdTipologiaCommessa",
                table: "XmlOpera",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MercePronta",
                table: "XmlOpera",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PercentualeFAcconto",
                table: "XmlOpera",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reso",
                table: "XmlOpera",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Stato",
                table: "XmlOpera",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
