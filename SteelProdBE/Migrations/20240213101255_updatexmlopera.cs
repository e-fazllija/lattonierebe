using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SteelProdBE.Migrations
{
    /// <inheritdoc />
    public partial class updatexmlopera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperaComponent_OperaColors_OperaColorsId",
                table: "OperaComponent");

            migrationBuilder.DropForeignKey(
                name: "FK_OperaComponent_OperaJobComponents_OperaJobComponentsId",
                table: "OperaComponent");

            migrationBuilder.DropForeignKey(
                name: "FK_OperaMaterial_OperaCuts_OperaCutsId",
                table: "OperaMaterial");

            migrationBuilder.DropIndex(
                name: "IX_OperaMaterial_OperaCutsId",
                table: "OperaMaterial");

            migrationBuilder.DropIndex(
                name: "IX_OperaComponent_OperaColorsId",
                table: "OperaComponent");

            migrationBuilder.DropColumn(
                name: "OperaCutsId",
                table: "OperaMaterial");

            migrationBuilder.DropColumn(
                name: "OperaColorsId",
                table: "OperaComponent");

            migrationBuilder.DropColumn(
                name: "OperaJobComponentId",
                table: "OperaComponent");

            migrationBuilder.RenameColumn(
                name: "MaterialId",
                table: "OperaCuts",
                newName: "OperaMaterialId");

            migrationBuilder.RenameColumn(
                name: "ComponentId",
                table: "OperaColors",
                newName: "OperaComponentId");

            migrationBuilder.AlterColumn<int>(
                name: "OperaJobComponentsId",
                table: "OperaComponent",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OperaCuts_OperaMaterialId",
                table: "OperaCuts",
                column: "OperaMaterialId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OperaColors_OperaComponentId",
                table: "OperaColors",
                column: "OperaComponentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OperaColors_OperaComponent_OperaComponentId",
                table: "OperaColors",
                column: "OperaComponentId",
                principalTable: "OperaComponent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OperaComponent_OperaJobComponents_OperaJobComponentsId",
                table: "OperaComponent",
                column: "OperaJobComponentsId",
                principalTable: "OperaJobComponents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OperaCuts_OperaMaterial_OperaMaterialId",
                table: "OperaCuts",
                column: "OperaMaterialId",
                principalTable: "OperaMaterial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperaColors_OperaComponent_OperaComponentId",
                table: "OperaColors");

            migrationBuilder.DropForeignKey(
                name: "FK_OperaComponent_OperaJobComponents_OperaJobComponentsId",
                table: "OperaComponent");

            migrationBuilder.DropForeignKey(
                name: "FK_OperaCuts_OperaMaterial_OperaMaterialId",
                table: "OperaCuts");

            migrationBuilder.DropIndex(
                name: "IX_OperaCuts_OperaMaterialId",
                table: "OperaCuts");

            migrationBuilder.DropIndex(
                name: "IX_OperaColors_OperaComponentId",
                table: "OperaColors");

            migrationBuilder.RenameColumn(
                name: "OperaMaterialId",
                table: "OperaCuts",
                newName: "MaterialId");

            migrationBuilder.RenameColumn(
                name: "OperaComponentId",
                table: "OperaColors",
                newName: "ComponentId");

            migrationBuilder.AddColumn<int>(
                name: "OperaCutsId",
                table: "OperaMaterial",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OperaJobComponentsId",
                table: "OperaComponent",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "OperaColorsId",
                table: "OperaComponent",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OperaJobComponentId",
                table: "OperaComponent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OperaMaterial_OperaCutsId",
                table: "OperaMaterial",
                column: "OperaCutsId");

            migrationBuilder.CreateIndex(
                name: "IX_OperaComponent_OperaColorsId",
                table: "OperaComponent",
                column: "OperaColorsId");

            migrationBuilder.AddForeignKey(
                name: "FK_OperaComponent_OperaColors_OperaColorsId",
                table: "OperaComponent",
                column: "OperaColorsId",
                principalTable: "OperaColors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OperaComponent_OperaJobComponents_OperaJobComponentsId",
                table: "OperaComponent",
                column: "OperaJobComponentsId",
                principalTable: "OperaJobComponents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OperaMaterial_OperaCuts_OperaCutsId",
                table: "OperaMaterial",
                column: "OperaCutsId",
                principalTable: "OperaCuts",
                principalColumn: "Id");
        }
    }
}
