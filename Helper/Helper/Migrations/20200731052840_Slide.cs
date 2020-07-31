using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class Slide : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13ec0778-28c0-4255-a5b7-a32a892bc16b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d17c9d99-aab5-4ddb-8473-bdac7974d14f");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TBL_Sliders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ffbb377b-05df-4647-8258-643b40a86a9e", "12201b9f-f3e2-4ead-a384-a51d071a974d", "Admin", "Admin" },
                    { "df779b39-c96a-4cbf-8c4f-47f13b290d58", "084b5c8e-2ff0-414f-9840-e939e6481bc4", "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 30, 22, 28, 40, 262, DateTimeKind.Local).AddTicks(2289));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 30, 22, 28, 40, 265, DateTimeKind.Local).AddTicks(7513));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df779b39-c96a-4cbf-8c4f-47f13b290d58");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffbb377b-05df-4647-8258-643b40a86a9e");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TBL_Sliders");

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
    }
}
