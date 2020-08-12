using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class ne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "eeeeeee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7550a06f-2cae-4630-9416-5a07ee23d4c9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4c4b559-2f82-436e-9621-256e0339bbc7");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f99dd69-46fb-42a7-8894-1745d09962b3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fdf97292-57f4-4724-8544-0627ce0d9944");

            migrationBuilder.CreateTable(
                name: "eeeeeee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eeeeeee", x => x.Id);
                });

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
    }
}
