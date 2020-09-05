using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class nqwq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 5, 15, 46, 30, 19, DateTimeKind.Local).AddTicks(1568));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 5, 15, 46, 30, 21, DateTimeKind.Local).AddTicks(9775));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 5, 15, 46, 30, 21, DateTimeKind.Local).AddTicks(9835));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 4, 13, 24, 34, 27, DateTimeKind.Local).AddTicks(7841));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 4, 13, 24, 34, 31, DateTimeKind.Local).AddTicks(2325));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 4, 13, 24, 34, 31, DateTimeKind.Local).AddTicks(2385));
        }
    }
}
