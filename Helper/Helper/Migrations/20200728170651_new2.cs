using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class new2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1dbed42-79bd-44e4-9317-66aee4a5e555");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8c04d85-1682-4410-9c58-58afabb91625");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "60529ca8-7666-4ce2-903c-39e7d25e2542", "3cbec140-f477-4711-b880-99863ed2a256", "Admin", "Admin" },
                    { "e6dbf045-5280-4c91-b7d8-bfbe62a4d19b", "5da0c1bf-8d64-479b-af01-083a81ce40c8", "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 28, 10, 6, 51, 340, DateTimeKind.Local).AddTicks(6506));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 28, 10, 6, 51, 344, DateTimeKind.Local).AddTicks(2156));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60529ca8-7666-4ce2-903c-39e7d25e2542");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6dbf045-5280-4c91-b7d8-bfbe62a4d19b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c8c04d85-1682-4410-9c58-58afabb91625", "6f732c4c-741f-4206-9441-2cc0b108e3f0", "Admin", "Admin" },
                    { "c1dbed42-79bd-44e4-9317-66aee4a5e555", "55a249a7-0c72-4718-9dc0-e7aa0838ed3a", "User", "Admin" }
                });

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 28, 10, 4, 53, 707, DateTimeKind.Local).AddTicks(6339));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 28, 10, 4, 53, 711, DateTimeKind.Local).AddTicks(1186));
        }
    }
}
