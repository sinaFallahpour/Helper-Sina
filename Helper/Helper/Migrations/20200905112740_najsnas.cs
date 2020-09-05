using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class najsnas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 5, 15, 57, 39, 635, DateTimeKind.Local).AddTicks(5452));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 5, 15, 57, 39, 639, DateTimeKind.Local).AddTicks(3028));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 5, 15, 57, 39, 639, DateTimeKind.Local).AddTicks(3119));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 5, 15, 48, 54, 8, DateTimeKind.Local).AddTicks(344));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 5, 15, 48, 54, 12, DateTimeKind.Local).AddTicks(576));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 5, 15, 48, 54, 12, DateTimeKind.Local).AddTicks(667));
        }
    }
}
