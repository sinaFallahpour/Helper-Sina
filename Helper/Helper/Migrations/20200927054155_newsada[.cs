using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class newsada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsReaded",
                table: "TBL_Service",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CreateServiceVM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Skills = table.Column<string>(maxLength: 600, nullable: false),
                    ServiceType = table.Column<int>(nullable: false),
                    IsAgreement = table.Column<bool>(nullable: false),
                    LikeCount = table.Column<int>(nullable: false),
                    CommentCount = table.Column<int>(nullable: false),
                    SeenCount = table.Column<int>(nullable: false),
                    IsSendByEmail = table.Column<bool>(nullable: false),
                    IsSendByNOtification = table.Column<bool>(nullable: false),
                    IsSendBySms = table.Column<bool>(nullable: false),
                    MinpRice = table.Column<double>(nullable: false),
                    MaxPrice = table.Column<double>(nullable: false),
                    CityId = table.Column<int>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    MonyUnitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreateServiceVM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ForgetPasswordVM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(maxLength: 30, nullable: false),
                    ReturnUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForgetPasswordVM", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 27, 9, 11, 54, 877, DateTimeKind.Local).AddTicks(3882));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 27, 9, 11, 54, 880, DateTimeKind.Local).AddTicks(1848));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 27, 9, 11, 54, 880, DateTimeKind.Local).AddTicks(1924));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 27, 9, 11, 54, 880, DateTimeKind.Local).AddTicks(1931));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 27, 9, 11, 54, 880, DateTimeKind.Local).AddTicks(1935));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 27, 9, 11, 54, 880, DateTimeKind.Local).AddTicks(1938));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 27, 9, 11, 54, 880, DateTimeKind.Local).AddTicks(1942));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreateServiceVM");

            migrationBuilder.DropTable(
                name: "ForgetPasswordVM");

            migrationBuilder.DropColumn(
                name: "IsReaded",
                table: "TBL_Service");

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 25, 7, 13, 5, 807, DateTimeKind.Local).AddTicks(1569));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 25, 7, 13, 5, 811, DateTimeKind.Local).AddTicks(9922));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 25, 7, 13, 5, 812, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 25, 7, 13, 5, 812, DateTimeKind.Local).AddTicks(8));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 25, 7, 13, 5, 812, DateTimeKind.Local).AddTicks(13));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 25, 7, 13, 5, 812, DateTimeKind.Local).AddTicks(18));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 25, 7, 13, 5, 812, DateTimeKind.Local).AddTicks(22));
        }
    }
}
