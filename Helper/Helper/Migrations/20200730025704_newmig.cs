using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class newmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fe8f0b2-732b-4e99-a2a4-106e221b3c14");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee3408dc-6808-4882-9a22-ea752ed9de04");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "13ec0778-28c0-4255-a5b7-a32a892bc16b", "167c56cb-144e-437f-8edf-f3ac1926cf71", "Admin", "Admin" },
                    { "d17c9d99-aab5-4ddb-8473-bdac7974d14f", "3ce2af39-0535-400c-ad39-8d4a101d0638", "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 19, 57, 3, 697, DateTimeKind.Local).AddTicks(7474));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 19, 57, 3, 708, DateTimeKind.Local).AddTicks(2605));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13ec0778-28c0-4255-a5b7-a32a892bc16b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d17c9d99-aab5-4ddb-8473-bdac7974d14f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ee3408dc-6808-4882-9a22-ea752ed9de04", "aa68f18b-344f-4aa6-9d40-70f74da812c0", "Admin", "Admin" },
                    { "7fe8f0b2-732b-4e99-a2a4-106e221b3c14", "b3326663-1e7c-482e-98b0-147194eeb7c6", "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 28, 22, 49, 5, 951, DateTimeKind.Local).AddTicks(5512));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 28, 22, 49, 5, 955, DateTimeKind.Local).AddTicks(2948));
        }
    }
}
