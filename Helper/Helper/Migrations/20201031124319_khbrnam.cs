using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class khbrnam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConfirmServiceType",
                table: "CreateServiceVM",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsReaded",
                table: "CreateServiceVM",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "TBL_SubscribeNew",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_SubscribeNew", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 31, 16, 13, 19, 78, DateTimeKind.Local).AddTicks(1731));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 31, 16, 13, 19, 80, DateTimeKind.Local).AddTicks(9095));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 31, 16, 13, 19, 80, DateTimeKind.Local).AddTicks(9165));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 31, 16, 13, 19, 80, DateTimeKind.Local).AddTicks(9172));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 31, 16, 13, 19, 80, DateTimeKind.Local).AddTicks(9176));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 31, 16, 13, 19, 80, DateTimeKind.Local).AddTicks(9179));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 31, 16, 13, 19, 80, DateTimeKind.Local).AddTicks(9183));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_SubscribeNew");

            migrationBuilder.DropColumn(
                name: "ConfirmServiceType",
                table: "CreateServiceVM");

            migrationBuilder.DropColumn(
                name: "IsReaded",
                table: "CreateServiceVM");

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
    }
}
