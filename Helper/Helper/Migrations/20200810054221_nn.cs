using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class nn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3f120f56-a027-45ff-99ff-d73c687722a8", "94f1ccd7-7912-4866-8e10-cd3e14425637", "Admin", "Admin" },
                    { "fe3b64b8-2b5a-4a26-86fe-3b3276bfabe9", "eb56940f-5681-49ce-bb4a-0cd5323673b3", "User", "User" }
                });

            migrationBuilder.InsertData(
                table: "TBL_Settings",
                columns: new[] { "Id", "CreatedAt", "Key", "UpdatedAt", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 8, 9, 22, 42, 20, 815, DateTimeKind.Local).AddTicks(824), "AboutUs", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "" },
                    { 2, new DateTime(2020, 8, 9, 22, 42, 20, 819, DateTimeKind.Local).AddTicks(5835), "Contactus", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f120f56-a027-45ff-99ff-d73c687722a8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe3b64b8-2b5a-4a26-86fe-3b3276bfabe9");

            migrationBuilder.DeleteData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
