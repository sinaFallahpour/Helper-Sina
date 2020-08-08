using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class newAppUse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f8ec8be-0edf-4591-b5fb-b5aa64920be0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48db39c3-ce91-4345-a842-973507854ddd");

            migrationBuilder.AddColumn<string>(
                name: "AccountOwner",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardNumber",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShabaNumber",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SiteLanguage",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "VisaNumber",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EditArticleViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 2500, nullable: false),
                    CreateDate = table.Column<string>(nullable: true),
                    NewsType = table.Column<int>(nullable: false),
                    ArticlePhotoAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditArticleViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EditNewsViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 2500, nullable: false),
                    CreateDate = table.Column<string>(nullable: true),
                    NewsType = table.Column<int>(nullable: false),
                    VideoAddress = table.Column<string>(nullable: true)
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

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 6, 15, 0, 22, 242, DateTimeKind.Local).AddTicks(3980));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 6, 15, 0, 22, 246, DateTimeKind.Local).AddTicks(314));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "AccountOwner",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BankName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CardNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ShabaNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SiteLanguage",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "VisaNumber",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3f8ec8be-0edf-4591-b5fb-b5aa64920be0", "ab40bac9-3317-4483-93bf-996f229387bd", "Admin", "Admin" },
                    { "48db39c3-ce91-4345-a842-973507854ddd", "afb967f8-1bc3-4243-9157-15b2354aa1f2", "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 3, 10, 40, 51, 208, DateTimeKind.Local).AddTicks(6854));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 3, 10, 40, 51, 212, DateTimeKind.Local).AddTicks(2525));
        }
    }
}
