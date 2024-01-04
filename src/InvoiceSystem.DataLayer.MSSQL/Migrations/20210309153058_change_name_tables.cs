using Microsoft.EntityFrameworkCore.Migrations;

namespace InvoiceSystem.DataLayer.MSSQL.Migrations
{
    public partial class change_name_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProducOrderDetailts_Orers_OrderId",
                table: "ProducOrderDetailts");

            migrationBuilder.DropTable(
                name: "MyTestModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProducOrderDetailts",
                table: "ProducOrderDetailts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orers",
                table: "Orers");

            migrationBuilder.RenameTable(
                name: "ProducOrderDetailts",
                newName: "OrderDetailts");

            migrationBuilder.RenameTable(
                name: "Orers",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_ProducOrderDetailts_OrderId",
                table: "OrderDetailts",
                newName: "IX_OrderDetailts_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetailts",
                table: "OrderDetailts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetailts_Orders_OrderId",
                table: "OrderDetailts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetailts_Orders_OrderId",
                table: "OrderDetailts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetailts",
                table: "OrderDetailts");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Orers");

            migrationBuilder.RenameTable(
                name: "OrderDetailts",
                newName: "ProducOrderDetailts");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetailts_OrderId",
                table: "ProducOrderDetailts",
                newName: "IX_ProducOrderDetailts_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orers",
                table: "Orers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProducOrderDetailts",
                table: "ProducOrderDetailts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MyTestModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyTestModels", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProducOrderDetailts_Orers_OrderId",
                table: "ProducOrderDetailts",
                column: "OrderId",
                principalTable: "Orers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
