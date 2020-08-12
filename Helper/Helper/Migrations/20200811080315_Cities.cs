using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class Cities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "618c91a9-c851-41fe-ab65-0bed970289b6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6520d777-7e1f-4448-950a-e42e535a138e");

            migrationBuilder.CreateTable(
                name: "TBL_City",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_City", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7a8793cf-071a-4196-b1fe-311e7a644b60", "2d67399f-e459-4372-a3f6-f08ea2c09ae4", "Admin", "Admin" },
                    { "df7be1a6-cd00-4f2c-874b-63a9a6de8d14", "7cea8724-f904-4901-85b5-a904ef823c5b", "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 11, 12, 33, 14, 791, DateTimeKind.Local).AddTicks(8902));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 11, 12, 33, 14, 795, DateTimeKind.Local).AddTicks(2349));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_City");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a8793cf-071a-4196-b1fe-311e7a644b60");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df7be1a6-cd00-4f2c-874b-63a9a6de8d14");

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
    }
}
