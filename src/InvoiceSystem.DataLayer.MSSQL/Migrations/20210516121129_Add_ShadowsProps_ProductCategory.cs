using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InvoiceSystem.DataLayer.MSSQL.Migrations
{
    public partial class Add_ShadowsProps_ProductCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedByBrowserName",
                table: "ProductCategories",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByIp",
                table: "ProductCategories",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "ProductCategories",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "ProductCategories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByBrowserName",
                table: "ProductCategories",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByIp",
                table: "ProductCategories",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "ProductCategories",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "ProductCategories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByBrowserName",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "CreatedByIp",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "ModifiedByBrowserName",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "ModifiedByIp",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "ProductCategories");
        }
    }
}
