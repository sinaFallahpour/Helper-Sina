using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class eleteIdentityRoleFrompplicationUSe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_ApplicationUserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_ApplicationUserId",
                table: "AspNetUserRoles");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df779b39-c96a-4cbf-8c4f-47f13b290d58");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffbb377b-05df-4647-8258-643b40a86a9e");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "AspNetUserRoles");

            migrationBuilder.CreateTable(
                name: "AdminProfileViewModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Username = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Nickname = table.Column<string>(maxLength: 200, nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    Birthdate = table.Column<string>(maxLength: 50, nullable: true),
                    NationalCode = table.Column<string>(maxLength: 10, nullable: true),
                    Phone = table.Column<string>(maxLength: 11, nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PhotoAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminProfileViewModel", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "246d51fe-4d13-4564-afc3-089338d2be39", "2cb5c96c-c2a8-49ae-b752-9b8293798894", "Admin", "Admin" },
                    { "4d915742-e905-4bba-b63d-0429110beaa5", "7f027f84-9b3f-4524-8d3a-a1bc8a4638af", "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 1, 1, 40, 58, 783, DateTimeKind.Local).AddTicks(2742));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 1, 1, 40, 58, 786, DateTimeKind.Local).AddTicks(7486));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminProfileViewModel");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "246d51fe-4d13-4564-afc3-089338d2be39");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d915742-e905-4bba-b63d-0429110beaa5");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "AspNetUserRoles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ffbb377b-05df-4647-8258-643b40a86a9e", "12201b9f-f3e2-4ead-a384-a51d071a974d", "Admin", "Admin" },
                    { "df779b39-c96a-4cbf-8c4f-47f13b290d58", "084b5c8e-2ff0-414f-9840-e939e6481bc4", "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 30, 22, 28, 40, 262, DateTimeKind.Local).AddTicks(2289));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 30, 22, 28, 40, 265, DateTimeKind.Local).AddTicks(7513));

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_ApplicationUserId",
                table: "AspNetUserRoles",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_ApplicationUserId",
                table: "AspNetUserRoles",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
