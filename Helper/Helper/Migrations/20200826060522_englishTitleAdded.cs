using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class englishTitleAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MonyEnglishName",
                table: "TBL_Plane_MonyUnit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnglishName",
                table: "TBL_MonyUnit",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EnglishName",
                table: "TBL_City",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EnglishName",
                table: "TBL_Category",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Skills",
                table: "CreateServiceVM",
                maxLength: 600,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(800)",
                oldMaxLength: 800);

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 26, 10, 35, 22, 171, DateTimeKind.Local).AddTicks(7113));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 26, 10, 35, 22, 174, DateTimeKind.Local).AddTicks(6332));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 26, 10, 35, 22, 174, DateTimeKind.Local).AddTicks(6397));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MonyEnglishName",
                table: "TBL_Plane_MonyUnit");

            migrationBuilder.DropColumn(
                name: "EnglishName",
                table: "TBL_MonyUnit");

            migrationBuilder.DropColumn(
                name: "EnglishName",
                table: "TBL_City");

            migrationBuilder.DropColumn(
                name: "EnglishName",
                table: "TBL_Category");

            migrationBuilder.AlterColumn<string>(
                name: "Skills",
                table: "CreateServiceVM",
                type: "nvarchar(800)",
                maxLength: 800,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 600);

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 25, 15, 2, 28, 459, DateTimeKind.Local).AddTicks(4723));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 25, 15, 2, 28, 462, DateTimeKind.Local).AddTicks(2368));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 25, 15, 2, 28, 462, DateTimeKind.Local).AddTicks(2434));
        }
    }
}
