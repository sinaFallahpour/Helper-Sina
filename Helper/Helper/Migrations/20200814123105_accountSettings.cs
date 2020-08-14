using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class accountSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_BankInfo",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    BankName = table.Column<string>(nullable: true),
                    AccountOwner = table.Column<string>(nullable: true),
                    CardNumber = table.Column<string>(nullable: true),
                    ShabaNumber = table.Column<string>(nullable: true),
                    VisaNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_BankInfo", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_TBL_BankInfo_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 14, 5, 31, 5, 179, DateTimeKind.Local).AddTicks(5100));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 14, 5, 31, 5, 183, DateTimeKind.Local).AddTicks(1999));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 14, 5, 31, 5, 183, DateTimeKind.Local).AddTicks(2059));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_BankInfo");

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 13, 6, 54, 22, 825, DateTimeKind.Local).AddTicks(212));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 13, 6, 54, 22, 828, DateTimeKind.Local).AddTicks(9008));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 13, 6, 54, 22, 828, DateTimeKind.Local).AddTicks(9063));
        }
    }
}
