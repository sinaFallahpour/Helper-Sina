using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class Servcice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab210a2c-0c3a-4e1b-a914-3934c83ceae2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0b5a3de-ee9c-4ed9-a460-bb92669f0d5f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad0cc2fb-3594-456b-a751-0985f8d95d37", "e0f55caa-bded-4565-8ba0-637d81a2f572", "Admin", "Admin" },
                    { "1e3e4ec7-0488-4dac-96ad-ea26fb51ccaf", "a9708268-dd7c-4a36-8b7a-6acc113f64c0", "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 10, 13, 33, 12, 202, DateTimeKind.Local).AddTicks(1692));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 10, 13, 33, 12, 205, DateTimeKind.Local).AddTicks(9281));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e3e4ec7-0488-4dac-96ad-ea26fb51ccaf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad0cc2fb-3594-456b-a751-0985f8d95d37");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f0b5a3de-ee9c-4ed9-a460-bb92669f0d5f", "944164ec-b6d5-4a7c-86b0-26e112c8ab32", "Admin", "Admin" },
                    { "ab210a2c-0c3a-4e1b-a914-3934c83ceae2", "632cec3b-e26b-4351-9972-26737e6c9d91", "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 10, 3, 34, 21, 208, DateTimeKind.Local).AddTicks(2535));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 10, 3, 34, 21, 211, DateTimeKind.Local).AddTicks(9680));
        }
    }
}
