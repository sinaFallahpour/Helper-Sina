using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class CtegoryCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80e27055-2d7c-4e51-9d62-91501984acf8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e29fd578-26dd-498c-ba15-efcff46fa322");

            migrationBuilder.CreateTable(
                name: "TBL_Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Category", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "34376638-26a9-4578-9e2c-dc0ff16d62cf", "ad0765fd-c071-4d89-a33d-be72d136d797", "Admin", "Admin" },
                    { "4c33780b-b29a-464e-9888-162cb33c9ff4", "9762b53a-fcc6-49db-aaaf-e93ff8f81bcc", "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 11, 10, 48, 22, 271, DateTimeKind.Local).AddTicks(5033));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 11, 10, 48, 22, 274, DateTimeKind.Local).AddTicks(2057));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_Category");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34376638-26a9-4578-9e2c-dc0ff16d62cf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c33780b-b29a-464e-9888-162cb33c9ff4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "80e27055-2d7c-4e51-9d62-91501984acf8", "21f7c6ce-84a3-40ca-81d9-bd16bff22f0a", "Admin", "Admin" },
                    { "e29fd578-26dd-498c-ba15-efcff46fa322", "2a6193b8-8ab0-4669-a90a-b983e04ae70e", "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 11, 9, 39, 48, 493, DateTimeKind.Local).AddTicks(2059));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 11, 9, 39, 48, 495, DateTimeKind.Local).AddTicks(8789));
        }
    }
}
