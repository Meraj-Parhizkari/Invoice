using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InvoiceSystem.DataLayer.MSSQL.Migrations
{
    public partial class AddNewModels_Post_PostGroup_PostPostGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "app");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDateTime",
                schema: "car",
                table: "CarFs",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "car",
                table: "CarFs",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "PostGroups",
                schema: "app",
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
                    Name = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 2147483647, nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    Status = table.Column<byte>(nullable: false),
                    LanguageId = table.Column<byte>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    Slug = table.Column<string>(nullable: true),
                    IsShowHomepage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostGroups_PostGroups_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "app",
                        principalTable: "PostGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                schema: "app",
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
                    Type = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 300, nullable: false),
                    Title = table.Column<string>(maxLength: 300, nullable: false),
                    Slug = table.Column<string>(maxLength: 150, nullable: false),
                    MetaKeywords = table.Column<string>(maxLength: 300, nullable: true),
                    PostSummery = table.Column<string>(maxLength: 1024, nullable: true),
                    MetaDescription = table.Column<string>(maxLength: 300, nullable: true),
                    PostContent = table.Column<string>(maxLength: 2147483647, nullable: false),
                    Image = table.Column<string>(nullable: true),
                    SmallImage = table.Column<string>(nullable: true),
                    MediumImage = table.Column<string>(nullable: true),
                    BigImage = table.Column<string>(nullable: true),
                    BackgroundImage = table.Column<string>(nullable: true),
                    VisitCount = table.Column<int>(nullable: false),
                    PostLike = table.Column<string>(nullable: true),
                    PostRate = table.Column<float>(nullable: false),
                    PublishDatetime = table.Column<DateTime>(nullable: false),
                    ExpiredDatetime = table.Column<DateTime>(nullable: true),
                    IsActiveComments = table.Column<bool>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostPostGroups",
                schema: "app",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false),
                    PostGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostPostGroups", x => new { x.PostId, x.PostGroupId });
                    table.ForeignKey(
                        name: "FK_PostPostGroups_PostGroups_PostGroupId",
                        column: x => x.PostGroupId,
                        principalSchema: "app",
                        principalTable: "PostGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostPostGroups_Posts_PostId",
                        column: x => x.PostId,
                        principalSchema: "app",
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostGroups_ParentId",
                schema: "app",
                table: "PostGroups",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_PostPostGroups_PostGroupId",
                schema: "app",
                table: "PostPostGroups",
                column: "PostGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostPostGroups",
                schema: "app");

            migrationBuilder.DropTable(
                name: "PostGroups",
                schema: "app");

            migrationBuilder.DropTable(
                name: "Posts",
                schema: "app");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ModifiedDateTime",
                schema: "car",
                table: "CarFs",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDateTime",
                schema: "car",
                table: "CarFs",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
