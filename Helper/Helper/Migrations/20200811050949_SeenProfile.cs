using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class SeenProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63a50bdf-4cf1-46ae-af05-11642b1979de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db77bb68-6d0a-4462-9e32-dae30cb9821b");

            migrationBuilder.CreateTable(
                name: "UserSeenProfile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CurrentUserId = table.Column<string>(nullable: true),
                    SeenerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSeenProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSeenProfile_AspNetUsers_CurrentUserId",
                        column: x => x.CurrentUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserSeenProfile_AspNetUsers_SeenerId",
                        column: x => x.SeenerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_UserSeenProfile_CurrentUserId",
                table: "UserSeenProfile",
                column: "CurrentUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSeenProfile_SeenerId",
                table: "UserSeenProfile",
                column: "SeenerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSeenProfile");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80e27055-2d7c-4e51-9d62-91501984acf8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e29fd578-26dd-498c-ba15-efcff46fa322");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "63a50bdf-4cf1-46ae-af05-11642b1979de", "1037029d-5536-4870-a85d-25429e6d95f6", "Admin", "Admin" },
                    { "db77bb68-6d0a-4462-9e32-dae30cb9821b", "9428f622-78b3-42bc-ad29-a16c2d0f0d14", "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 10, 14, 21, 12, 944, DateTimeKind.Local).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 10, 14, 21, 12, 948, DateTimeKind.Local).AddTicks(5769));
        }
    }
}
