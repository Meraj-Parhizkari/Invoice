using Microsoft.EntityFrameworkCore.Migrations;

namespace InvoiceSystem.DataLayer.MSSQL.Migrations
{
    public partial class Chenge_table_OrderDetailts_to_OrderDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetailts_Orders_OrderId",
                table: "OrderDetailts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetailts",
                table: "OrderDetailts");

            migrationBuilder.RenameTable(
                name: "OrderDetailts",
                newName: "OrderDetails");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetailts_OrderId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails");

            migrationBuilder.RenameTable(
                name: "OrderDetails",
                newName: "OrderDetailts");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetailts",
                newName: "IX_OrderDetailts_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetailts",
                table: "OrderDetailts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetailts_Orders_OrderId",
                table: "OrderDetailts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
