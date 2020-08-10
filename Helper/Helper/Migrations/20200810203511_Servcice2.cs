using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class Servcice2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e3e4ec7-0488-4dac-96ad-ea26fb51ccaf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad0cc2fb-3594-456b-a751-0985f8d95d37");

            migrationBuilder.CreateTable(
                name: "TBL_Service",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Skills = table.Column<string>(nullable: true),
                    ServiceType = table.Column<int>(nullable: false),
                    SendType = table.Column<int>(nullable: false),
                    IsAgreement = table.Column<bool>(nullable: false),
                    LikeCount = table.Column<int>(nullable: false),
                    CommentCount = table.Column<int>(nullable: false),
                    SeenCount = table.Column<int>(nullable: false),
                    MinpRice = table.Column<int>(nullable: false),
                    MaxPrice = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Service", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_Service_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a7b49ed6-8e25-42cc-a0ba-951cddd8bf55", "0d197605-f7b8-469f-9454-0df034eab42a", "Admin", "Admin" },
                    { "58a81558-e582-4293-b2c8-7a5b17b0764b", "e296356a-726f-4d22-b29d-66fe64f9fa56", "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 10, 13, 35, 11, 476, DateTimeKind.Local).AddTicks(3007));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 10, 13, 35, 11, 479, DateTimeKind.Local).AddTicks(7653));

            migrationBuilder.CreateIndex(
                name: "IX_TBL_Service_UserId",
                table: "TBL_Service",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_Service");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58a81558-e582-4293-b2c8-7a5b17b0764b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7b49ed6-8e25-42cc-a0ba-951cddd8bf55");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad0cc2fb-3594-456b-a751-0985f8d95d37", "e0f55caa-bded-4565-8ba0-637d81a2f572", "Admin", "Admin" },
                    { "1e3e4ec7-0488-4dac-96ad-ea26fb51ccaf", "a9708268-dd7c-4a36-8b7a-6acc113f64c0", "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 10, 13, 33, 12, 202, DateTimeKind.Local).AddTicks(1692));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 10, 13, 33, 12, 205, DateTimeKind.Local).AddTicks(9281));
        }
    }
}
