using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class Monynit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a8793cf-071a-4196-b1fe-311e7a644b60");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df7be1a6-cd00-4f2c-874b-63a9a6de8d14");

            migrationBuilder.CreateTable(
                name: "eeeeeee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    IsEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eeeeeee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_MonyUnit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_MonyUnit", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c4f63eda-b4fb-4e56-bcb2-1a659dd2318f", "6edd52f5-57ce-4d0b-a31e-ba2af33d8bfd", "Admin", "Admin" },
                    { "9bdc8ed8-706a-4aa9-9a61-7c24974a0745", "d3c8b62b-7923-4c92-a558-429e21107442", "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 11, 13, 41, 46, 90, DateTimeKind.Local).AddTicks(1578));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 11, 13, 41, 46, 93, DateTimeKind.Local).AddTicks(1959));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "eeeeeee");

            migrationBuilder.DropTable(
                name: "TBL_MonyUnit");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bdc8ed8-706a-4aa9-9a61-7c24974a0745");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4f63eda-b4fb-4e56-bcb2-1a659dd2318f");

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
    }
}
