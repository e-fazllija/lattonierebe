using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SteelProdBE.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_MaterialTypes_MaterialTypeId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_MaterialTypeId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "BarLength",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "BarsCount",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "DeliveryTiming",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "Depth",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "MaterialTypeId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "PackagingQuantity",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "Thickness",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "Profiles");

            migrationBuilder.RenameColumn(
                name: "Width",
                table: "Profiles",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "WeightPerMeter",
                table: "Profiles",
                newName: "PackageQuantity");

            migrationBuilder.RenameColumn(
                name: "MaterialQuality",
                table: "Profiles",
                newName: "DeliveryTimeframe");

            migrationBuilder.RenameColumn(
                name: "InternalCode",
                table: "Profiles",
                newName: "Code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Profiles",
                newName: "Width");

            migrationBuilder.RenameColumn(
                name: "PackageQuantity",
                table: "Profiles",
                newName: "WeightPerMeter");

            migrationBuilder.RenameColumn(
                name: "DeliveryTimeframe",
                table: "Profiles",
                newName: "MaterialQuality");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Profiles",
                newName: "InternalCode");

            migrationBuilder.AddColumn<decimal>(
                name: "BarLength",
                table: "Profiles",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "BarsCount",
                table: "Profiles",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryTiming",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Depth",
                table: "Profiles",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Height",
                table: "Profiles",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaterialTypeId",
                table: "Profiles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PackagingQuantity",
                table: "Profiles",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Thickness",
                table: "Profiles",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "Profiles",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_MaterialTypeId",
                table: "Profiles",
                column: "MaterialTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_MaterialTypes_MaterialTypeId",
                table: "Profiles",
                column: "MaterialTypeId",
                principalTable: "MaterialTypes",
                principalColumn: "Id");
        }
    }
}
