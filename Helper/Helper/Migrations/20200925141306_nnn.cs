using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class nnn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 25, 7, 13, 5, 807, DateTimeKind.Local).AddTicks(1569));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 25, 7, 13, 5, 811, DateTimeKind.Local).AddTicks(9922));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 25, 7, 13, 5, 812, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 25, 7, 13, 5, 812, DateTimeKind.Local).AddTicks(8));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 25, 7, 13, 5, 812, DateTimeKind.Local).AddTicks(13));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 25, 7, 13, 5, 812, DateTimeKind.Local).AddTicks(18));

            migrationBuilder.InsertData(
                table: "TBL_Settings",
                columns: new[] { "Id", "CreatedAt", "EnglishValue", "Key", "UpdatedAt", "Value" },
                values: new object[] { 7, new DateTime(2020, 9, 25, 7, 13, 5, 812, DateTimeKind.Local).AddTicks(22), "", "CreateServiceText", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 25, 2, 46, 29, 222, DateTimeKind.Local).AddTicks(9747));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 25, 2, 46, 29, 226, DateTimeKind.Local).AddTicks(8183));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 25, 2, 46, 29, 226, DateTimeKind.Local).AddTicks(8266));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 25, 2, 46, 29, 226, DateTimeKind.Local).AddTicks(8275));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 25, 2, 46, 29, 226, DateTimeKind.Local).AddTicks(8279));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 25, 2, 46, 29, 226, DateTimeKind.Local).AddTicks(8284));
        }
    }
}
