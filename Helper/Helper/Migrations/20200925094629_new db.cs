using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class newdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 25, 2, 46, 29, 222, DateTimeKind.Local).AddTicks(9747));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 25, 2, 46, 29, 226, DateTimeKind.Local).AddTicks(8183));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 25, 2, 46, 29, 226, DateTimeKind.Local).AddTicks(8266));

            migrationBuilder.InsertData(
                table: "TBL_Settings",
                columns: new[] { "Id", "CreatedAt", "EnglishValue", "Key", "UpdatedAt", "Value" },
                values: new object[,]
                {
                    { 4, new DateTime(2020, 9, 25, 2, 46, 29, 226, DateTimeKind.Local).AddTicks(8275), "", "landingHelperText", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "" },
                    { 5, new DateTime(2020, 9, 25, 2, 46, 29, 226, DateTimeKind.Local).AddTicks(8279), "", "ForUserText", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "" },
                    { 6, new DateTime(2020, 9, 25, 2, 46, 29, 226, DateTimeKind.Local).AddTicks(8284), "", "ForProfessionalText", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 7, 12, 53, 58, 572, DateTimeKind.Local).AddTicks(9163));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 7, 12, 53, 58, 575, DateTimeKind.Local).AddTicks(8746));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 7, 12, 53, 58, 575, DateTimeKind.Local).AddTicks(8814));
        }
    }
}
