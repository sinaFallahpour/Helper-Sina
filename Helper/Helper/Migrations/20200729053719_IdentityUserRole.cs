using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class IdentityUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60529ca8-7666-4ce2-903c-39e7d25e2542");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6dbf045-5280-4c91-b7d8-bfbe62a4d19b");

            migrationBuilder.AddColumn<string>(
                name: "RolesId",
                table: "AspNetUserRoles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                table: "AspNetUserRoles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUserRoles",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "91a22380-39c9-470d-bd5f-782555a79051", "4060bdb0-5774-44db-9702-ce4e2fcb63eb", "Admin", "Admin" },
                    { "5dceb720-14c9-4d61-bb1e-d7826358bec3", "32a43b2a-b711-4e7f-9e58-bdef191fe362", "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 28, 22, 37, 18, 574, DateTimeKind.Local).AddTicks(5236));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 28, 22, 37, 18, 578, DateTimeKind.Local).AddTicks(3789));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: "5dceb720-14c9-4d61-bb1e-d7826358bec3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91a22380-39c9-470d-bd5f-782555a79051");

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
                    { "60529ca8-7666-4ce2-903c-39e7d25e2542", "3cbec140-f477-4711-b880-99863ed2a256", "Admin", "Admin" },
                    { "e6dbf045-5280-4c91-b7d8-bfbe62a4d19b", "5da0c1bf-8d64-479b-af01-083a81ce40c8", "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 28, 10, 6, 51, 340, DateTimeKind.Local).AddTicks(6506));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 28, 10, 6, 51, 344, DateTimeKind.Local).AddTicks(2156));
        }
    }
}
