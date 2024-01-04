using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InvoiceSystem.DataLayer.MSSQL.Migrations
{
    public partial class ChangeModelName_CarFs_to_BaseCars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarFs_CarBrandId",
                schema: "Car",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarFs_CarModelId",
                schema: "Car",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarFs_CarTypeId",
                schema: "Car",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "CarFs",
                schema: "Car");

            migrationBuilder.CreateTable(
                name: "BaseCars",
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
                    Cid = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    CarFType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseCars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseCars_BaseCars_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "Car",
                        principalTable: "BaseCars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseCars_ParentId",
                schema: "Car",
                table: "BaseCars",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_BaseCars_CarBrandId",
                schema: "Car",
                table: "Cars",
                column: "CarBrandId",
                principalSchema: "Car",
                principalTable: "BaseCars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_BaseCars_CarModelId",
                schema: "Car",
                table: "Cars",
                column: "CarModelId",
                principalSchema: "Car",
                principalTable: "BaseCars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_BaseCars_CarTypeId",
                schema: "Car",
                table: "Cars",
                column: "CarTypeId",
                principalSchema: "Car",
                principalTable: "BaseCars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_BaseCars_CarBrandId",
                schema: "Car",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_BaseCars_CarModelId",
                schema: "Car",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_BaseCars_CarTypeId",
                schema: "Car",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "BaseCars",
                schema: "Car");

            migrationBuilder.CreateTable(
                name: "CarFs",
                schema: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    CarFType = table.Column<int>(type: "int", nullable: false),
                    Cid = table.Column<int>(type: "int", nullable: false),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarFs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarFs_CarFs_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "Car",
                        principalTable: "CarFs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarFs_ParentId",
                schema: "Car",
                table: "CarFs",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarFs_CarBrandId",
                schema: "Car",
                table: "Cars",
                column: "CarBrandId",
                principalSchema: "Car",
                principalTable: "CarFs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarFs_CarModelId",
                schema: "Car",
                table: "Cars",
                column: "CarModelId",
                principalSchema: "Car",
                principalTable: "CarFs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarFs_CarTypeId",
                schema: "Car",
                table: "Cars",
                column: "CarTypeId",
                principalSchema: "Car",
                principalTable: "CarFs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
