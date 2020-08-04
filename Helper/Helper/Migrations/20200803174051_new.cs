using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBL_NewsComment_TBL_NewsArticleVideo_NewsId",
                table: "TBL_NewsComment");

            migrationBuilder.DropForeignKey(
                name: "FK_TBL_NewsLike_TBL_NewsArticleVideo_NewsId",
                table: "TBL_NewsLike");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb2f58ba-d33a-49a4-8785-1b297d2b7b92");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0f939b9-db87-4144-baa0-e0b0f26dc028");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "TBL_NewsArticleVideo",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(550)",
                oldMaxLength: 550);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TBL_NewsArticleVideo",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1500)",
                oldMaxLength: 1500);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3f8ec8be-0edf-4591-b5fb-b5aa64920be0", "ab40bac9-3317-4483-93bf-996f229387bd", "Admin", "Admin" },
                    { "48db39c3-ce91-4345-a842-973507854ddd", "afb967f8-1bc3-4243-9157-15b2354aa1f2", "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 3, 10, 40, 51, 208, DateTimeKind.Local).AddTicks(6854));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 3, 10, 40, 51, 212, DateTimeKind.Local).AddTicks(2525));

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_NewsComment_TBL_NewsArticleVideo_NewsId",
                table: "TBL_NewsComment",
                column: "NewsId",
                principalTable: "TBL_NewsArticleVideo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_NewsLike_TBL_NewsArticleVideo_NewsId",
                table: "TBL_NewsLike",
                column: "NewsId",
                principalTable: "TBL_NewsArticleVideo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBL_NewsComment_TBL_NewsArticleVideo_NewsId",
                table: "TBL_NewsComment");

            migrationBuilder.DropForeignKey(
                name: "FK_TBL_NewsLike_TBL_NewsArticleVideo_NewsId",
                table: "TBL_NewsLike");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f8ec8be-0edf-4591-b5fb-b5aa64920be0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48db39c3-ce91-4345-a842-973507854ddd");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "TBL_NewsArticleVideo",
                type: "nvarchar(550)",
                maxLength: 550,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TBL_NewsArticleVideo",
                type: "nvarchar(1500)",
                maxLength: 1500,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 2000);

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

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_NewsComment_TBL_NewsArticleVideo_NewsId",
                table: "TBL_NewsComment",
                column: "NewsId",
                principalTable: "TBL_NewsArticleVideo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_NewsLike_TBL_NewsArticleVideo_NewsId",
                table: "TBL_NewsLike",
                column: "NewsId",
                principalTable: "TBL_NewsArticleVideo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
