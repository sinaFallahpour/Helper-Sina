using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class updatedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "ConfirmServiceType",
                table: "TBL_Service",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "HasProviderService",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ServiceListVM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LikeCount = table.Column<int>(nullable: false),
                    CommentCount = table.Column<int>(nullable: false),
                    SeenCount = table.Column<int>(nullable: false),
                    IsLiked = table.Column<bool>(nullable: false),
                    CategoryName = table.Column<string>(nullable: true),
                    CategoryImageAddres = table.Column<string>(nullable: true),
                    UserImageAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceListVM", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 4, 11, 23, 10, 421, DateTimeKind.Local).AddTicks(8141));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 4, 11, 23, 10, 425, DateTimeKind.Local).AddTicks(3824));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 4, 11, 23, 10, 425, DateTimeKind.Local).AddTicks(3888));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceListVM");

            migrationBuilder.DropColumn(
                name: "ConfirmServiceType",
                table: "TBL_Service");

            migrationBuilder.DropColumn(
                name: "HasProviderService",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 31, 12, 24, 1, 888, DateTimeKind.Local).AddTicks(7540));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 31, 12, 24, 1, 892, DateTimeKind.Local).AddTicks(3814));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 31, 12, 24, 1, 892, DateTimeKind.Local).AddTicks(3975));
        }
    }
}
