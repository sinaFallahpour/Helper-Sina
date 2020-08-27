using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class newss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "TBL_Service",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OtherUserProfile",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Nickname = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Descriptions = table.Column<string>(nullable: true),
                    Birthdate = table.Column<string>(nullable: true),
                    LanguageKnowing = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    MarriedType = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    SKILLS = table.Column<string>(nullable: true),
                    PhotoAddress = table.Column<string>(nullable: true),
                    MaghTa = table.Column<string>(nullable: true),
                    UnivercityName = table.Column<string>(nullable: true),
                    EduEnterDate = table.Column<string>(nullable: true),
                    EduExitDate = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    Semat = table.Column<string>(nullable: true),
                    WorkEnterDate = table.Column<string>(nullable: true),
                    WorkExitDate = table.Column<string>(nullable: true),
                    WorkDescriptions = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherUserProfile", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 27, 12, 45, 29, 407, DateTimeKind.Local).AddTicks(8948));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 27, 12, 45, 29, 411, DateTimeKind.Local).AddTicks(7239));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 27, 12, 45, 29, 411, DateTimeKind.Local).AddTicks(7427));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OtherUserProfile");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "TBL_Service");

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 26, 14, 35, 41, 412, DateTimeKind.Local).AddTicks(4771));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 26, 14, 35, 41, 417, DateTimeKind.Local).AddTicks(3737));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 26, 14, 35, 41, 417, DateTimeKind.Local).AddTicks(3866));
        }
    }
}
