using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SteelProdBE.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessoryTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessoryTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bpfs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    XmlId = table.Column<int>(type: "int", nullable: false),
                    WorkOrderId = table.Column<int>(type: "int", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Error = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bpfs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerTypeId = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdministrativeOfficeAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdministrativeOfficeZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdministrativeOfficeCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdministrativeOfficeCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdministrativeOfficeProvince = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperatingOfficeAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperatingOfficeZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperatingOfficeCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperatingOfficeCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperatingOfficeProvince = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipientAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipientZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipientCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipientCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipientProvince = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FiscalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PEC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniqueCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceAgent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: true),
                    BankCoordinates = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Increment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryMethodId = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DDTs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    XmlId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    DdtNumber = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_DDTs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GoodReceiptTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodReceiptTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    AdvancePayment = table.Column<bool>(type: "bit", nullable: false),
                    Amount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Percentage = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Markings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdFac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dx = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Larg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Str = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaterialTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModulesXml",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameXmlOpera = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dx = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Da = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NRip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DxRip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoundDx = table.Column<bool>(type: "bit", nullable: false),
                    CeilDx = table.Column<bool>(type: "bit", nullable: false),
                    RoundDa = table.Column<bool>(type: "bit", nullable: false),
                    CeilDa = table.Column<bool>(type: "bit", nullable: false),
                    RoundNRip = table.Column<bool>(type: "bit", nullable: false),
                    CeilNRip = table.Column<bool>(type: "bit", nullable: false),
                    RoundDxRip = table.Column<bool>(type: "bit", nullable: false),
                    CeilDxRip = table.Column<bool>(type: "bit", nullable: false),
                    DeltaX = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvanzamentoDeltaX = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoopCutIdCode = table.Column<bool>(type: "bit", nullable: false),
                    ByCustomer = table.Column<bool>(type: "bit", nullable: false),
                    ByMaterial = table.Column<bool>(type: "bit", nullable: false),
                    CutNameStart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CutNameEnd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ByRange = table.Column<bool>(type: "bit", nullable: false),
                    MaterialColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ByMaterialColor = table.Column<bool>(type: "bit", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ByModel = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModulesXml", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Identifier = table.Column<int>(type: "int", nullable: false),
                    EntityClassTypologie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntityClassId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seen = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperaColors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComponentId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperaColors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperaCuts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperaCuts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstPayment = table.Column<int>(type: "int", nullable: false),
                    SecondPayment = table.Column<int>(type: "int", nullable: false),
                    ThirdPayment = table.Column<int>(type: "int", nullable: false),
                    FourthPayment = table.Column<int>(type: "int", nullable: false),
                    FifthPayment = table.Column<int>(type: "int", nullable: false),
                    AdditionalPayment = table.Column<int>(type: "int", nullable: false),
                    AdditionalPaymentFollowingMonth = table.Column<bool>(type: "bit", nullable: false),
                    InvoiceDate = table.Column<bool>(type: "bit", nullable: false),
                    TotalPayments = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProTubeJobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    XmlId = table.Column<int>(type: "int", nullable: false),
                    ProTubeJobId = table.Column<int>(type: "int", nullable: false),
                    JobName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobBarNum = table.Column<int>(type: "int", nullable: true),
                    JobBarTotLen = table.Column<double>(type: "float", nullable: true),
                    JobEstProdTime = table.Column<long>(type: "bigint", nullable: true),
                    JobScrapPerc = table.Column<int>(type: "int", nullable: true),
                    JobPartNumPlaced = table.Column<int>(type: "int", nullable: true),
                    JobNestPercPartPlacing = table.Column<int>(type: "int", nullable: true),
                    JobTransferred = table.Column<bool>(type: "bit", nullable: false),
                    Nesting = table.Column<bool>(type: "bit", nullable: false),
                    TransferError = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilesQuantityUpdated = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProTubeJobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfileTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileTypeId = table.Column<int>(type: "int", nullable: true),
                    InternalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierArticleCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitOfMeasure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Width = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Height = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Depth = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Thickness = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    WeightPerMeter = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    BarLength = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    MaterialTypeId = table.Column<int>(type: "int", nullable: true),
                    PackagingQuantity = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    MaterialQuality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinimumStock = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    BarsCount = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryTiming = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryMethodId = table.Column<int>(type: "int", nullable: true),
                    LastDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfilesXml",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilesXml", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "XmlOpera",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipologiaCommessa = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataApprontamentoMerce = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataAccreditoAcconto = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DDTGenerato = table.Column<bool>(type: "bit", nullable: false),
                    FAccontoGenerata = table.Column<bool>(type: "bit", nullable: false),
                    PercentualeFAcconto = table.Column<int>(type: "int", nullable: true),
                    TotaleFAcconto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatturaGenerata = table.Column<bool>(type: "bit", nullable: false),
                    MercePronta = table.Column<bool>(type: "bit", nullable: false),
                    Reso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileCommessa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileAccessori = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileOrdine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Errore = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XmlOpera", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DDTComponents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DDTId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "OperaColor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperaColorsId = table.Column<int>(type: "int", nullable: false),
                    PKEY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FKEY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    col_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    col_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperaColor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperaColor_OperaColors_OperaColorsId",
                        column: x => x.OperaColorsId,
                        principalTable: "OperaColors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperaCut",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperaCutsId = table.Column<int>(type: "int", nullable: false),
                    cut_idcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cut_pieces = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cut_lenght_external = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cut_lenght_internal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cut_lenght_max = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cut_lenght_tube = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cut_lenght_encumbrance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cut_leftangle_wt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cut_rightangle_wt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    wt_piece_of_piece = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperaCut", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperaCut_OperaCuts_OperaCutsId",
                        column: x => x.OperaCutsId,
                        principalTable: "OperaCuts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniqueCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FiscalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<long>(type: "bigint", nullable: true),
                    Mobile = table.Column<long>(type: "bigint", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PEC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceAgent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTypeId = table.Column<int>(type: "int", nullable: true),
                    BankDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    XmlOperaId = table.Column<int>(type: "int", nullable: false),
                    job_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    job_year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    job_creator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    job_creation_timestamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    job_order_reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    job_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    job_status_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    job_vat_rate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Job_XmlOpera_XmlOperaId",
                        column: x => x.XmlOperaId,
                        principalTable: "XmlOpera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperaMachinings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperaCutId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperaMachinings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperaMachinings_OperaCut_OperaCutId",
                        column: x => x.OperaCutId,
                        principalTable: "OperaCut",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accessories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAccessoryType = table.Column<int>(type: "int", nullable: true),
                    AccessoryTypeId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierArticleCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitOfMeasure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    PackageQuantity = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    MinimumStock = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryTimeframe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryTypeId = table.Column<int>(type: "int", nullable: true),
                    LastDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accessories_AccessoryTypes_AccessoryTypeId",
                        column: x => x.AccessoryTypeId,
                        principalTable: "AccessoryTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accessories_DeliveryTypes_DeliveryTypeId",
                        column: x => x.DeliveryTypeId,
                        principalTable: "DeliveryTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Accessories_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GoodReceipts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentNumber = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeID = table.Column<int>(type: "int", nullable: false),
                    GoodId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitOfMeasure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodReceipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoodReceipts_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InternalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierArticleCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitOfMeasure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Function = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    PackagingQuantity = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    MinimumStock = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryTiming = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryMethodId = table.Column<int>(type: "int", nullable: true),
                    MaterialTypeId = table.Column<int>(type: "int", nullable: true),
                    LastDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materials_MaterialTypes_MaterialTypeId",
                        column: x => x.MaterialTypeId,
                        principalTable: "MaterialTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Materials_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OperaJobComponents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperaJobComponents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperaJobComponents_Job_JobId",
                        column: x => x.JobId,
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperaJobCustomer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    cst_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cst_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperaJobCustomer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperaJobCustomer_Job_JobId",
                        column: x => x.JobId,
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperaJobPrice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    job_last_saved_price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperaJobPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperaJobPrice_Job_JobId",
                        column: x => x.JobId,
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperaMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperaMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperaMaterials_Job_JobId",
                        column: x => x.JobId,
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperaMachining",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperaMachiningsId = table.Column<int>(type: "int", nullable: false),
                    mach_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperaMachining", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperaMachining_OperaMachinings_OperaMachiningsId",
                        column: x => x.OperaMachiningsId,
                        principalTable: "OperaMachinings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperaComponent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperaJobComponentId = table.Column<int>(type: "int", nullable: false),
                    cmp_idcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cmp_quantity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cmp_category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cmp_system = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cmp_series = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cmp_width = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cmp_height = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cmp_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cmp_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cmp_price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cmp_vat_rate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cmp_panes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperaColorsId = table.Column<int>(type: "int", nullable: true),
                    OperaJobComponentsId = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperaComponent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperaComponent_OperaColors_OperaColorsId",
                        column: x => x.OperaColorsId,
                        principalTable: "OperaColors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OperaComponent_OperaJobComponents_OperaJobComponentsId",
                        column: x => x.OperaJobComponentsId,
                        principalTable: "OperaJobComponents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OperaMaterial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperaMaterialsId = table.Column<int>(type: "int", nullable: false),
                    mat_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mat_system = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mat_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mat_profile_function_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mat_profile_function = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mat_profile_function2_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mat_profile_function2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mat_profile_function3_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mat_profile_function3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mat_alternative_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mat_supplier_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mat_quantity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mat_quantity_on_unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mat_width = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperaCutsId = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperaMaterial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperaMaterial_OperaCuts_OperaCutsId",
                        column: x => x.OperaCutsId,
                        principalTable: "OperaCuts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OperaMaterial_OperaMaterials_OperaMaterialsId",
                        column: x => x.OperaMaterialsId,
                        principalTable: "OperaMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperaMaterialColors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperaMaterialId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperaMaterialColors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperaMaterialColors_OperaMaterial_OperaMaterialId",
                        column: x => x.OperaMaterialId,
                        principalTable: "OperaMaterial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperaMaterialColor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperaMaterialColorsId = table.Column<int>(type: "int", nullable: false),
                    PKEY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FKEY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    col_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    col_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperaMaterialColor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperaMaterialColor_OperaMaterialColors_OperaMaterialColorsId",
                        column: x => x.OperaMaterialColorsId,
                        principalTable: "OperaMaterialColors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accessories_AccessoryTypeId",
                table: "Accessories",
                column: "AccessoryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Accessories_DeliveryTypeId",
                table: "Accessories",
                column: "DeliveryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Accessories_SupplierId",
                table: "Accessories",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DDTComponents_DDTId",
                table: "DDTComponents",
                column: "DDTId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodReceipts_SupplierId",
                table: "GoodReceipts",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_XmlOperaId",
                table: "Job",
                column: "XmlOperaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materials_MaterialTypeId",
                table: "Materials",
                column: "MaterialTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_SupplierId",
                table: "Materials",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_OperaColor_OperaColorsId",
                table: "OperaColor",
                column: "OperaColorsId");

            migrationBuilder.CreateIndex(
                name: "IX_OperaComponent_OperaColorsId",
                table: "OperaComponent",
                column: "OperaColorsId");

            migrationBuilder.CreateIndex(
                name: "IX_OperaComponent_OperaJobComponentsId",
                table: "OperaComponent",
                column: "OperaJobComponentsId");

            migrationBuilder.CreateIndex(
                name: "IX_OperaCut_OperaCutsId",
                table: "OperaCut",
                column: "OperaCutsId");

            migrationBuilder.CreateIndex(
                name: "IX_OperaJobComponents_JobId",
                table: "OperaJobComponents",
                column: "JobId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OperaJobCustomer_JobId",
                table: "OperaJobCustomer",
                column: "JobId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OperaJobPrice_JobId",
                table: "OperaJobPrice",
                column: "JobId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OperaMachining_OperaMachiningsId",
                table: "OperaMachining",
                column: "OperaMachiningsId");

            migrationBuilder.CreateIndex(
                name: "IX_OperaMachinings_OperaCutId",
                table: "OperaMachinings",
                column: "OperaCutId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OperaMaterial_OperaCutsId",
                table: "OperaMaterial",
                column: "OperaCutsId");

            migrationBuilder.CreateIndex(
                name: "IX_OperaMaterial_OperaMaterialsId",
                table: "OperaMaterial",
                column: "OperaMaterialsId");

            migrationBuilder.CreateIndex(
                name: "IX_OperaMaterialColor_OperaMaterialColorsId",
                table: "OperaMaterialColor",
                column: "OperaMaterialColorsId");

            migrationBuilder.CreateIndex(
                name: "IX_OperaMaterialColors_OperaMaterialId",
                table: "OperaMaterialColors",
                column: "OperaMaterialId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OperaMaterials_JobId",
                table: "OperaMaterials",
                column: "JobId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_PaymentTypeId",
                table: "Suppliers",
                column: "PaymentTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accessories");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bpfs");

            migrationBuilder.DropTable(
                name: "CustomerTypes");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "DDTComponents");

            migrationBuilder.DropTable(
                name: "GoodReceiptTypes");

            migrationBuilder.DropTable(
                name: "GoodReceipts");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Markings");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "ModulesXml");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "OperaColor");

            migrationBuilder.DropTable(
                name: "OperaComponent");

            migrationBuilder.DropTable(
                name: "OperaJobCustomer");

            migrationBuilder.DropTable(
                name: "OperaJobPrice");

            migrationBuilder.DropTable(
                name: "OperaMachining");

            migrationBuilder.DropTable(
                name: "OperaMaterialColor");

            migrationBuilder.DropTable(
                name: "ProTubeJobs");

            migrationBuilder.DropTable(
                name: "ProfileTypes");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "ProfilesXml");

            migrationBuilder.DropTable(
                name: "AccessoryTypes");

            migrationBuilder.DropTable(
                name: "DeliveryTypes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "DDTs");

            migrationBuilder.DropTable(
                name: "MaterialTypes");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "OperaColors");

            migrationBuilder.DropTable(
                name: "OperaJobComponents");

            migrationBuilder.DropTable(
                name: "OperaMachinings");

            migrationBuilder.DropTable(
                name: "OperaMaterialColors");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "OperaCut");

            migrationBuilder.DropTable(
                name: "OperaMaterial");

            migrationBuilder.DropTable(
                name: "OperaCuts");

            migrationBuilder.DropTable(
                name: "OperaMaterials");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "XmlOpera");
        }
    }
}
