using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class new5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RolesId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UsersId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_RolesId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UsersId",
                table: "AspNetUserRoles");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45fe9955-159e-4704-8e96-3d8b41f4f38d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba08da0c-75c8-429a-a59d-cf921a8cc2c0");

            migrationBuilder.DropColumn(
                name: "RolesId",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUserRoles");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ee3408dc-6808-4882-9a22-ea752ed9de04", "aa68f18b-344f-4aa6-9d40-70f74da812c0", "Admin", "Admin" },
                    { "7fe8f0b2-732b-4e99-a2a4-106e221b3c14", "b3326663-1e7c-482e-98b0-147194eeb7c6", "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 28, 22, 49, 5, 951, DateTimeKind.Local).AddTicks(5512));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 28, 22, 49, 5, 955, DateTimeKind.Local).AddTicks(2948));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fe8f0b2-732b-4e99-a2a4-106e221b3c14");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee3408dc-6808-4882-9a22-ea752ed9de04");

            migrationBuilder.AddColumn<string>(
                name: "RolesId",
                table: "AspNetUserRoles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                table: "AspNetUserRoles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUserRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "45fe9955-159e-4704-8e96-3d8b41f4f38d", "bc900704-999b-4b06-aed1-94e58503c429", "Admin", "Admin" },
                    { "ba08da0c-75c8-429a-a59d-cf921a8cc2c0", "d7b577fd-b103-4877-bc47-e57e80d47efc", "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 28, 22, 47, 26, 598, DateTimeKind.Local).AddTicks(9315));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 28, 22, 47, 26, 602, DateTimeKind.Local).AddTicks(9280));

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RolesId",
                table: "AspNetUserRoles",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UsersId",
                table: "AspNetUserRoles",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RolesId",
                table: "AspNetUserRoles",
                column: "RolesId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UsersId",
                table: "AspNetUserRoles",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
