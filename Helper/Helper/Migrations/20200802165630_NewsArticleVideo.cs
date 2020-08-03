using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class NewsArticleVideo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminProfileViewModel");

            migrationBuilder.DropTable(
                name: "TBL_AboutUs");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "246d51fe-4d13-4564-afc3-089338d2be39");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d915742-e905-4bba-b63d-0429110beaa5");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TBL_Sliders",
                maxLength: 550,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "TBL_NewsArticleVideo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 550, nullable: false),
                    Description = table.Column<string>(maxLength: 1500, nullable: false),
                    CreateDate = table.Column<string>(nullable: true),
                    LikesCount = table.Column<int>(nullable: false),
                    CommentsCount = table.Column<int>(nullable: false),
                    SeenCount = table.Column<int>(nullable: false),
                    NewsType = table.Column<int>(nullable: false),
                    ArticlePhotoAddress = table.Column<string>(nullable: true),
                    VideoAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_NewsArticleVideo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_NewsComment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(maxLength: 1500, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    NewsId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_NewsComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_NewsComment_TBL_NewsArticleVideo_NewsId",
                        column: x => x.NewsId,
                        principalTable: "TBL_NewsArticleVideo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBL_NewsComment_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBL_NewsLike",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrateDate = table.Column<DateTime>(nullable: false),
                    NewsId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_NewsLike", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_NewsLike_TBL_NewsArticleVideo_NewsId",
                        column: x => x.NewsId,
                        principalTable: "TBL_NewsArticleVideo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBL_NewsLike_AspNetUsers_UserId",
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
                    { "cb2f58ba-d33a-49a4-8785-1b297d2b7b92", "ddd20dbd-4f7f-4b17-947b-0c34ece0d1c9", "Admin", "Admin" },
                    { "e0f939b9-db87-4144-baa0-e0b0f26dc028", "f78f0f71-5dbd-4d95-b5c5-bbfd25b42525", "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 2, 9, 56, 29, 772, DateTimeKind.Local).AddTicks(5263));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 2, 9, 56, 29, 777, DateTimeKind.Local).AddTicks(2837));

            migrationBuilder.CreateIndex(
                name: "IX_TBL_NewsComment_NewsId",
                table: "TBL_NewsComment",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_NewsComment_UserId",
                table: "TBL_NewsComment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_NewsLike_NewsId",
                table: "TBL_NewsLike",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_NewsLike_UserId",
                table: "TBL_NewsLike",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_NewsComment");

            migrationBuilder.DropTable(
                name: "TBL_NewsLike");

            migrationBuilder.DropTable(
                name: "TBL_NewsArticleVideo");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb2f58ba-d33a-49a4-8785-1b297d2b7b92");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0f939b9-db87-4144-baa0-e0b0f26dc028");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TBL_Sliders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 550);

            migrationBuilder.CreateTable(
                name: "AdminProfileViewModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthdate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NationalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Nickname = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    PhotoAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminProfileViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_AboutUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_AboutUs", x => x.Id);
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
    }
}
