using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InvoiceSystem.DataLayer.MSSQL.Migrations
{
    public partial class AddNewModels_Car_and_Others : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Car");

            migrationBuilder.RenameTable(
                name: "CarFs",
                schema: "car",
                newName: "CarFs",
                newSchema: "Car");

            migrationBuilder.CreateTable(
                name: "CarBodyStatuses",
                schema: "Car",
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
                    AgentId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarBodyStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarColors",
                schema: "Car",
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
                    AgentId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    ColorType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarColors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarDocs",
                schema: "Car",
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
                    AgentId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarDocs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                schema: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByBrowserName = table.Column<string>(maxLength: 1000, nullable: true),
                    ModifiedByBrowserName = table.Column<string>(maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedByIp = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    ModifiedByUserId = table.Column<int>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    AgentId = table.Column<int>(nullable: false),
                    CarBrandId = table.Column<int>(nullable: false),
                    CarModelId = table.Column<int>(nullable: false),
                    CarTypeId = table.Column<int>(nullable: false),
                    CarBodyStatusId = table.Column<int>(nullable: false),
                    BodyCarColorId = table.Column<int>(nullable: false),
                    InsideCarColorId = table.Column<int>(nullable: false),
                    CarYear = table.Column<int>(nullable: false),
                    CarKilometer = table.Column<int>(nullable: false),
                    CarStatusId = table.Column<int>(nullable: false),
                    CarPlateTypeId = table.Column<int>(nullable: false),
                    CarPayStatus = table.Column<int>(nullable: false),
                    CarPrice = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    CarVisitLocation = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CarStatus = table.Column<int>(nullable: false),
                    CarTypeStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_CarColors_BodyCarColorId",
                        column: x => x.BodyCarColorId,
                        principalSchema: "Car",
                        principalTable: "CarColors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_CarBodyStatuses_CarBodyStatusId",
                        column: x => x.CarBodyStatusId,
                        principalSchema: "Car",
                        principalTable: "CarBodyStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_CarFs_CarBrandId",
                        column: x => x.CarBrandId,
                        principalSchema: "Car",
                        principalTable: "CarFs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_CarFs_CarModelId",
                        column: x => x.CarModelId,
                        principalSchema: "Car",
                        principalTable: "CarFs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_CarFs_CarTypeId",
                        column: x => x.CarTypeId,
                        principalSchema: "Car",
                        principalTable: "CarFs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_CarColors_InsideCarColorId",
                        column: x => x.InsideCarColorId,
                        principalSchema: "Car",
                        principalTable: "CarColors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarImages",
                schema: "Car",
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
                    AgentId = table.Column<int>(nullable: false),
                    CarId = table.Column<int>(nullable: false),
                    Filename = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarImages_Cars_CarId",
                        column: x => x.CarId,
                        principalSchema: "Car",
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarColors_Name",
                schema: "Car",
                table: "CarColors",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarDocs_Name",
                schema: "Car",
                table: "CarDocs",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarImages_CarId",
                schema: "Car",
                table: "CarImages",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BodyCarColorId",
                schema: "Car",
                table: "Cars",
                column: "BodyCarColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarBodyStatusId",
                schema: "Car",
                table: "Cars",
                column: "CarBodyStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarBrandId",
                schema: "Car",
                table: "Cars",
                column: "CarBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarModelId",
                schema: "Car",
                table: "Cars",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarTypeId",
                schema: "Car",
                table: "Cars",
                column: "CarTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CreatedByUserId",
                schema: "Car",
                table: "Cars",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_InsideCarColorId",
                schema: "Car",
                table: "Cars",
                column: "InsideCarColorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarDocs",
                schema: "Car");

            migrationBuilder.DropTable(
                name: "CarImages",
                schema: "Car");

            migrationBuilder.DropTable(
                name: "Cars",
                schema: "Car");

            migrationBuilder.DropTable(
                name: "CarColors",
                schema: "Car");

            migrationBuilder.DropTable(
                name: "CarBodyStatuses",
                schema: "Car");

            migrationBuilder.EnsureSchema(
                name: "car");

            migrationBuilder.RenameTable(
                name: "CarFs",
                schema: "Car",
                newName: "CarFs",
                newSchema: "car");
        }
    }
}
