using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class newMigartion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBL_Plane_MonyUnit_TBL_MonyUnit_MonyUnitId",
                table: "TBL_Plane_MonyUnit");

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 14, 8, 36, 59, 708, DateTimeKind.Local).AddTicks(4891));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 14, 8, 36, 59, 712, DateTimeKind.Local).AddTicks(273));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 14, 8, 36, 59, 712, DateTimeKind.Local).AddTicks(333));

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_Plane_MonyUnit_TBL_MonyUnit_MonyUnitId",
                table: "TBL_Plane_MonyUnit",
                column: "MonyUnitId",
                principalTable: "TBL_MonyUnit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBL_Plane_MonyUnit_TBL_MonyUnit_MonyUnitId",
                table: "TBL_Plane_MonyUnit");

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 14, 8, 0, 44, 591, DateTimeKind.Local).AddTicks(8772));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 14, 8, 0, 44, 595, DateTimeKind.Local).AddTicks(6226));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 14, 8, 0, 44, 595, DateTimeKind.Local).AddTicks(6289));

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_Plane_MonyUnit_TBL_MonyUnit_MonyUnitId",
                table: "TBL_Plane_MonyUnit",
                column: "MonyUnitId",
                principalTable: "TBL_MonyUnit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
