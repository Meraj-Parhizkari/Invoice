using Microsoft.EntityFrameworkCore.Migrations;

namespace InvoiceSystem.DataLayer.MSSQL.Migrations
{
    public partial class add_table_MyMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mymenus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    PId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mymenus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mymenus_Mymenus_PId",
                        column: x => x.PId,
                        principalTable: "Mymenus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mymenus_PId",
                table: "Mymenus",
                column: "PId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mymenus");
        }
    }
}
