using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class newD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_UserCommentService",
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
                    table.PrimaryKey("PK_TBL_UserCommentService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_UserCommentService_TBL_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "TBL_Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBL_UserCommentService_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBL_UserLikeSerive",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    ServiceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_UserLikeSerive", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_UserLikeSerive_TBL_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "TBL_Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBL_UserLikeSerive_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBL_UserSeenProfile",
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
                    table.PrimaryKey("PK_TBL_UserSeenProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_UserSeenProfile_AspNetUsers_CurrentUserId",
                        column: x => x.CurrentUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBL_UserSeenProfile_AspNetUsers_SeenerId",
                        column: x => x.SeenerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 14, 5, 47, 20, 268, DateTimeKind.Local).AddTicks(7030));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 14, 5, 47, 20, 272, DateTimeKind.Local).AddTicks(1983));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 14, 5, 47, 20, 272, DateTimeKind.Local).AddTicks(2039));

            migrationBuilder.CreateIndex(
                name: "IX_TBL_UserCommentService_ServiceId",
                table: "TBL_UserCommentService",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_UserCommentService_UserId",
                table: "TBL_UserCommentService",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_UserLikeSerive_ServiceId",
                table: "TBL_UserLikeSerive",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_UserLikeSerive_UserId",
                table: "TBL_UserLikeSerive",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_UserSeenProfile_CurrentUserId",
                table: "TBL_UserSeenProfile",
                column: "CurrentUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_UserSeenProfile_SeenerId",
                table: "TBL_UserSeenProfile",
                column: "SeenerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_UserCommentService");

            migrationBuilder.DropTable(
                name: "TBL_UserLikeSerive");

            migrationBuilder.DropTable(
                name: "TBL_UserSeenProfile");

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 14, 5, 43, 38, 648, DateTimeKind.Local).AddTicks(8566));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 14, 5, 43, 38, 652, DateTimeKind.Local).AddTicks(3443));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 14, 5, 43, 38, 652, DateTimeKind.Local).AddTicks(3500));
        }
    }
}
