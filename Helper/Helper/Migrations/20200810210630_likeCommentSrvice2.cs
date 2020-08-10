using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class likeCommentSrvice2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58a81558-e582-4293-b2c8-7a5b17b0764b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7b49ed6-8e25-42cc-a0ba-951cddd8bf55");

            migrationBuilder.CreateTable(
                name: "TBL_ServiceLevel2",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    MonthCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_ServiceLevel2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserCommentService",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(maxLength: 1500, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    ServiceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCommentService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCommentService_TBL_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "TBL_Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserCommentService_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserLikeSerive",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    ServiceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLikeSerive", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLikeSerive_TBL_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "TBL_Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserLikeSerive_AspNetUsers_UserId",
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
                    { "554f0ca2-1a09-42fc-a1a3-84c4c6b69926", "b752e118-5a7a-4f4e-a179-3935d6a5cf82", "Admin", "Admin" },
                    { "196d3d14-4214-4330-8428-2ad077bfa247", "f0a8ac7b-3460-4157-bb69-2eef4e51cec7", "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 10, 14, 6, 29, 404, DateTimeKind.Local).AddTicks(8900));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 10, 14, 6, 29, 408, DateTimeKind.Local).AddTicks(4664));

            migrationBuilder.CreateIndex(
                name: "IX_UserCommentService_ServiceId",
                table: "UserCommentService",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCommentService_UserId",
                table: "UserCommentService",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLikeSerive_ServiceId",
                table: "UserLikeSerive",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLikeSerive_UserId",
                table: "UserLikeSerive",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_ServiceLevel2");

            migrationBuilder.DropTable(
                name: "UserCommentService");

            migrationBuilder.DropTable(
                name: "UserLikeSerive");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "196d3d14-4214-4330-8428-2ad077bfa247");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "554f0ca2-1a09-42fc-a1a3-84c4c6b69926");

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
        }
    }
}
