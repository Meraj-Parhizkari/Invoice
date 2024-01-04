using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InvoiceSystem.DataLayer.MSSQL.Migrations
{
    public partial class add_baseTables_and_navigations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AgentId",
                schema: "Car",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "AgentId",
                schema: "Car",
                table: "CarImages");

            migrationBuilder.DropColumn(
                name: "AgentId",
                schema: "Car",
                table: "CarDocs");

            migrationBuilder.DropColumn(
                name: "AgentId",
                schema: "Car",
                table: "CarColors");

            migrationBuilder.DropColumn(
                name: "AgentId",
                schema: "Car",
                table: "CarBodyStatuses");

            migrationBuilder.DropColumn(
                name: "AgentId",
                schema: "Car",
                table: "BaseCars");

            migrationBuilder.DropColumn(
                name: "AgentId",
                schema: "app",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "AgentId",
                schema: "app",
                table: "PostGroups");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedByBrowserName",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedByIp",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ModifiedByBrowserName",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ModifiedByIp",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "SystemId",
                schema: "Car",
                table: "Cars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SystemId",
                schema: "Car",
                table: "CarImages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SystemId",
                schema: "Car",
                table: "CarDocs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SystemId",
                schema: "Car",
                table: "CarColors",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SystemId",
                schema: "Car",
                table: "CarBodyStatuses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SystemId",
                schema: "Car",
                table: "BaseCars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SystemId",
                schema: "app",
                table: "Posts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SystemId",
                schema: "app",
                table: "PostGroups",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProdactCategoryId",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductCategoryId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductCode",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CountryDivisions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryDivisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryDivisions_CountryDivisions_ParentId",
                        column: x => x.ParentId,
                        principalTable: "CountryDivisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByBrowserName = table.Column<string>(nullable: true),
                    ModifiedByBrowserName = table.Column<string>(nullable: true),
                    CreatedByIp = table.Column<string>(nullable: true),
                    ModifiedByIp = table.Column<string>(nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    ModifiedByUserId = table.Column<int>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    SystemId = table.Column<int>(nullable: false),
                    SellerId = table.Column<int>(nullable: false),
                    BuyerId = table.Column<int>(nullable: false),
                    OrderNumber = table.Column<int>(nullable: false),
                    CreatDatetime = table.Column<DateTime>(nullable: false),
                    OrderDatetime = table.Column<DateTime>(nullable: false),
                    CheckedOut = table.Column<bool>(nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    Total_Discount = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    TotalTax = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    TotalPay = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    Description = table.Column<string>(nullable: true),
                    UserDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByBrowserName = table.Column<string>(nullable: true),
                    ModifiedByBrowserName = table.Column<string>(nullable: true),
                    CreatedByIp = table.Column<string>(nullable: true),
                    ModifiedByIp = table.Column<string>(nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    ModifiedByUserId = table.Column<int>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    SystemId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    EconomicalNumber = table.Column<string>(nullable: true),
                    RegisterNumber = table.Column<string>(nullable: true),
                    TownId = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    NationalCode = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    PersonTypeId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategories_ProductCategories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProducOrderDetailts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(nullable: false),
                    productId = table.Column<int>(nullable: false),
                    ProductCount = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    Unit = table.Column<string>(nullable: true),
                    ProductPrice = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    ProductDiscunt = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    ProductTax = table.Column<decimal>(type: "decimal(18, 6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProducOrderDetailts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProducOrderDetailts_Orers_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryDivisions_ParentId",
                table: "CountryDivisions",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProducOrderDetailts_OrderId",
                table: "ProducOrderDetailts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ParentId",
                table: "ProductCategories",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "CountryDivisions");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "ProducOrderDetailts");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Orers");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SystemId",
                schema: "Car",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "SystemId",
                schema: "Car",
                table: "CarImages");

            migrationBuilder.DropColumn(
                name: "SystemId",
                schema: "Car",
                table: "CarDocs");

            migrationBuilder.DropColumn(
                name: "SystemId",
                schema: "Car",
                table: "CarColors");

            migrationBuilder.DropColumn(
                name: "SystemId",
                schema: "Car",
                table: "CarBodyStatuses");

            migrationBuilder.DropColumn(
                name: "SystemId",
                schema: "Car",
                table: "BaseCars");

            migrationBuilder.DropColumn(
                name: "SystemId",
                schema: "app",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "SystemId",
                schema: "app",
                table: "PostGroups");

            migrationBuilder.DropColumn(
                name: "ProdactCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductCode",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                schema: "Car",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                schema: "Car",
                table: "CarImages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                schema: "Car",
                table: "CarDocs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                schema: "Car",
                table: "CarColors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                schema: "Car",
                table: "CarBodyStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                schema: "Car",
                table: "BaseCars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                schema: "app",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                schema: "app",
                table: "PostGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByBrowserName",
                table: "Products",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByIp",
                table: "Products",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByBrowserName",
                table: "Products",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByIp",
                table: "Products",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18, 6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
