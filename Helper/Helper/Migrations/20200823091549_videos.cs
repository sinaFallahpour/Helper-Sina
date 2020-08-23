using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class videos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "TBL_Service");

            migrationBuilder.AddColumn<string>(
                name: "EnglishArticlePhotoAddress",
                table: "TBL_NewsArticleVideo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnglishDescription",
                table: "TBL_NewsArticleVideo",
                maxLength: 2000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EnglishTitle",
                table: "TBL_NewsArticleVideo",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EnglishVideoAddress",
                table: "TBL_NewsArticleVideo",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CreateServiceVM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 80, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Skills = table.Column<string>(maxLength: 800, nullable: false),
                    ServiceType = table.Column<int>(nullable: false),
                    IsAgreement = table.Column<bool>(nullable: false),
                    LikeCount = table.Column<int>(nullable: false),
                    CommentCount = table.Column<int>(nullable: false),
                    SeenCount = table.Column<int>(nullable: false),
                    IsSendByEmail = table.Column<bool>(nullable: false),
                    IsSendByNOtification = table.Column<bool>(nullable: false),
                    IsSendBySms = table.Column<bool>(nullable: false),
                    MinpRice = table.Column<int>(nullable: false),
                    MaxPrice = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    MonyUnitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreateServiceVM", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 13, 45, 49, 358, DateTimeKind.Local).AddTicks(5483));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 13, 45, 49, 361, DateTimeKind.Local).AddTicks(2750));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 13, 45, 49, 361, DateTimeKind.Local).AddTicks(2817));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreateServiceVM");

            migrationBuilder.DropColumn(
                name: "EnglishArticlePhotoAddress",
                table: "TBL_NewsArticleVideo");

            migrationBuilder.DropColumn(
                name: "EnglishDescription",
                table: "TBL_NewsArticleVideo");

            migrationBuilder.DropColumn(
                name: "EnglishTitle",
                table: "TBL_NewsArticleVideo");

            migrationBuilder.DropColumn(
                name: "EnglishVideoAddress",
                table: "TBL_NewsArticleVideo");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "TBL_Service",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 22, 11, 12, 58, 314, DateTimeKind.Local).AddTicks(5151));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 22, 11, 12, 58, 317, DateTimeKind.Local).AddTicks(1834));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 22, 11, 12, 58, 317, DateTimeKind.Local).AddTicks(1889));
        }
    }
}
