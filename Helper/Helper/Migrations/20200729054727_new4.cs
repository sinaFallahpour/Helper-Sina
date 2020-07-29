using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class new4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c4e3898-a258-40a7-b849-9c6b66b3e0b5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c64602ef-5c98-4d33-a5da-0ad520a32ec7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "45fe9955-159e-4704-8e96-3d8b41f4f38d", "bc900704-999b-4b06-aed1-94e58503c429", "Admin", "Admin" },
                    { "ba08da0c-75c8-429a-a59d-cf921a8cc2c0", "d7b577fd-b103-4877-bc47-e57e80d47efc", "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 28, 22, 47, 26, 598, DateTimeKind.Local).AddTicks(9315));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 28, 22, 47, 26, 602, DateTimeKind.Local).AddTicks(9280));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45fe9955-159e-4704-8e96-3d8b41f4f38d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba08da0c-75c8-429a-a59d-cf921a8cc2c0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c64602ef-5c98-4d33-a5da-0ad520a32ec7", "009266be-c588-41d7-b552-5309c7f2996f", "Admin", "Admin" },
                    { "3c4e3898-a258-40a7-b849-9c6b66b3e0b5", "641d3833-53b5-4846-8b44-611943e620d7", "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 28, 22, 43, 18, 943, DateTimeKind.Local).AddTicks(1843));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 28, 22, 43, 18, 947, DateTimeKind.Local).AddTicks(7664));
        }
    }
}
