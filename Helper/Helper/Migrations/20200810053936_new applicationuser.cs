using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class newapplicationuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EditArticleViewModel");

            migrationBuilder.DropTable(
                name: "EditNewsViewModel");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f005e57-70cb-4457-8a38-00208735a75e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf8fc038-91a5-4fe7-b865-6b0aa83c19a0");

            migrationBuilder.DeleteData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<string>(
                name: "Descriptions",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsMarid",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LanguageKnowing",
                table: "AspNetUsers",
                maxLength: 300,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descriptions",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsMarid",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LanguageKnowing",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "EditArticleViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticlePhotoAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
                    NewsType = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditArticleViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EditNewsViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
                    NewsType = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VideoAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditNewsViewModel", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bf8fc038-91a5-4fe7-b865-6b0aa83c19a0", "db25f6d8-05cb-4c0e-85df-782149fce163", "Admin", "Admin" },
                    { "4f005e57-70cb-4457-8a38-00208735a75e", "378981fc-b204-461e-8200-01dc3d764e30", "User", "User" }
                });

            migrationBuilder.InsertData(
                table: "TBL_Settings",
                columns: new[] { "Id", "CreatedAt", "Key", "UpdatedAt", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 8, 6, 15, 0, 22, 242, DateTimeKind.Local).AddTicks(3980), "AboutUs", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "" },
                    { 2, new DateTime(2020, 8, 6, 15, 0, 22, 246, DateTimeKind.Local).AddTicks(314), "Contactus", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "" }
                });
        }
    }
}
