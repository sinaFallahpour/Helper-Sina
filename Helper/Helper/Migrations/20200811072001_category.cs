using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34376638-26a9-4578-9e2c-dc0ff16d62cf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c33780b-b29a-464e-9888-162cb33c9ff4");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TBL_Category",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "TBL_Category",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "618c91a9-c851-41fe-ab65-0bed970289b6", "0ea23db9-3b3d-41d2-b846-7c7be1fc8811", "Admin", "Admin" },
                    { "6520d777-7e1f-4448-950a-e42e535a138e", "ec9ec9de-9bd9-4415-828b-45093bb23483", "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 11, 11, 50, 0, 342, DateTimeKind.Local).AddTicks(6883));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 11, 11, 50, 0, 787, DateTimeKind.Local).AddTicks(4525));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "618c91a9-c851-41fe-ab65-0bed970289b6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6520d777-7e1f-4448-950a-e42e535a138e");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "TBL_Category");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TBL_Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

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
    }
}
