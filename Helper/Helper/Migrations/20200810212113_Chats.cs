using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class Chats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "196d3d14-4214-4330-8428-2ad077bfa247");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "554f0ca2-1a09-42fc-a1a3-84c4c6b69926");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "63a50bdf-4cf1-46ae-af05-11642b1979de", "1037029d-5536-4870-a85d-25429e6d95f6", "Admin", "Admin" },
                    { "db77bb68-6d0a-4462-9e32-dae30cb9821b", "9428f622-78b3-42bc-ad29-a16c2d0f0d14", "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 10, 14, 21, 12, 944, DateTimeKind.Local).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 10, 14, 21, 12, 948, DateTimeKind.Local).AddTicks(5769));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63a50bdf-4cf1-46ae-af05-11642b1979de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db77bb68-6d0a-4462-9e32-dae30cb9821b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "554f0ca2-1a09-42fc-a1a3-84c4c6b69926", "b752e118-5a7a-4f4e-a179-3935d6a5cf82", "Admin", "Admin" },
                    { "196d3d14-4214-4330-8428-2ad077bfa247", "f0a8ac7b-3460-4157-bb69-2eef4e51cec7", "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 10, 14, 6, 29, 404, DateTimeKind.Local).AddTicks(8900));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 10, 14, 6, 29, 408, DateTimeKind.Local).AddTicks(4664));
        }
    }
}
