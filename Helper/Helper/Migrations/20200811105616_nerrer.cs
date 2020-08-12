using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class nerrer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f99dd69-46fb-42a7-8894-1745d09962b3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fdf97292-57f4-4724-8544-0627ce0d9944");

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 11, 15, 26, 16, 287, DateTimeKind.Local).AddTicks(2559));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 11, 15, 26, 16, 290, DateTimeKind.Local).AddTicks(7817));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5f99dd69-46fb-42a7-8894-1745d09962b3", "17b537d6-d43a-46ce-985e-a411783fa0d7", "Admin", "Admin" },
                    { "fdf97292-57f4-4724-8544-0627ce0d9944", "a915b269-eb87-44a8-98cb-1eb7c2f81824", "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 11, 14, 53, 14, 439, DateTimeKind.Local).AddTicks(8781));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 11, 14, 53, 14, 448, DateTimeKind.Local).AddTicks(7587));
        }
    }
}
