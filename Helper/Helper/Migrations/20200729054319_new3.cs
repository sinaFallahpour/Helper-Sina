using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class new3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5dceb720-14c9-4d61-bb1e-d7826358bec3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91a22380-39c9-470d-bd5f-782555a79051");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "91a22380-39c9-470d-bd5f-782555a79051", "4060bdb0-5774-44db-9702-ce4e2fcb63eb", "Admin", "Admin" },
                    { "5dceb720-14c9-4d61-bb1e-d7826358bec3", "32a43b2a-b711-4e7f-9e58-bdef191fe362", "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 28, 22, 37, 18, 574, DateTimeKind.Local).AddTicks(5236));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 28, 22, 37, 18, 578, DateTimeKind.Local).AddTicks(3789));
        }
    }
}
