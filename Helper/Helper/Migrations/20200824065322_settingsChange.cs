using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class settingsChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EnglishValue",
                table: "TBL_Settings",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EnglishValue" },
                values: new object[] { new DateTime(2020, 8, 24, 11, 23, 22, 351, DateTimeKind.Local).AddTicks(7920), "" });

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EnglishValue" },
                values: new object[] { new DateTime(2020, 8, 24, 11, 23, 22, 355, DateTimeKind.Local).AddTicks(786), "" });

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EnglishValue" },
                values: new object[] { new DateTime(2020, 8, 24, 11, 23, 22, 355, DateTimeKind.Local).AddTicks(874), "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnglishValue",
                table: "TBL_Settings");

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
    }
}
