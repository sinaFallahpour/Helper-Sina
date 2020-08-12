using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class nnn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bdc8ed8-706a-4aa9-9a61-7c24974a0745");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4f63eda-b4fb-4e56-bcb2-1a659dd2318f");

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "TBL_MonyUnit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "TBL_City",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "TBL_Category",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7550a06f-2cae-4630-9416-5a07ee23d4c9", "0a35447a-ad29-48f7-a3e5-54fbcfeb523b", "Admin", "Admin" },
                    { "e4c4b559-2f82-436e-9621-256e0339bbc7", "abcfa1b6-ecce-428f-a4fe-2a162d9f105c", "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 11, 13, 46, 13, 319, DateTimeKind.Local).AddTicks(9303));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 11, 13, 46, 13, 322, DateTimeKind.Local).AddTicks(7830));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7550a06f-2cae-4630-9416-5a07ee23d4c9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4c4b559-2f82-436e-9621-256e0339bbc7");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "TBL_MonyUnit");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "TBL_City");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "TBL_Category");

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
    }
}
