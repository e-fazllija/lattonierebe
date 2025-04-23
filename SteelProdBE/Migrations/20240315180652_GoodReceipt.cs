using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SteelProdBE.Migrations
{
    /// <inheritdoc />
    public partial class GoodReceipt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DDTComponents");

            migrationBuilder.DropTable(
                name: "DDTs");

            migrationBuilder.DropColumn(
                name: "UnitOfMeasure",
                table: "GoodReceipts");

            migrationBuilder.RenameColumn(
                name: "TypeID",
                table: "GoodReceipts",
                newName: "TypeId");

            migrationBuilder.CreateTable(
                name: "TransportDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    XmlId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    DocumentNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Packages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vehicle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aspect = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonForTransportation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisiblePrice = table.Column<bool>(type: "bit", nullable: false),
                    WithdrawalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    COP1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    COP2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpettabileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpettabileAddress1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpettabileAddress2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpettabileVatNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpettabileFiscalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportDocuments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransportComponents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransportDocumentId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportComponents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportComponents_TransportDocuments_TransportDocumentId",
                        column: x => x.TransportDocumentId,
                        principalTable: "TransportDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransportComponents_TransportDocumentId",
                table: "TransportComponents",
                column: "TransportDocumentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransportComponents");

            migrationBuilder.DropTable(
                name: "TransportDocuments");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "GoodReceipts",
                newName: "TypeID");

            migrationBuilder.AddColumn<string>(
                name: "UnitOfMeasure",
                table: "GoodReceipts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DDTs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aspect = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    COP1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    COP2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DdtNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Packages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonForTransportation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpettabileAddress1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpettabileAddress2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpettabileFiscalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpettabileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpettabileVatNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Vector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vehicle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisiblePrice = table.Column<bool>(type: "bit", nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WithdrawalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    XmlId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DDTs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DDTComponents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DDTId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DDTComponents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DDTComponents_DDTs_DDTId",
                        column: x => x.DDTId,
                        principalTable: "DDTs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DDTComponents_DDTId",
                table: "DDTComponents",
                column: "DDTId");
        }
    }
}
