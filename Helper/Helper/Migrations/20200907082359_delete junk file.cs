using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class deletejunkfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreateServiceVM");

            migrationBuilder.DropTable(
                name: "OtherUserProfile");

            migrationBuilder.DropTable(
                name: "ServiceListVM");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreateServiceVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    CommentCount = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsAgreement = table.Column<bool>(type: "bit", nullable: false),
                    IsSendByEmail = table.Column<bool>(type: "bit", nullable: false),
                    IsSendByNOtification = table.Column<bool>(type: "bit", nullable: false),
                    IsSendBySms = table.Column<bool>(type: "bit", nullable: false),
                    LikeCount = table.Column<int>(type: "int", nullable: false),
                    MaxPrice = table.Column<double>(type: "float", nullable: false),
                    MinpRice = table.Column<double>(type: "float", nullable: false),
                    MonyUnitId = table.Column<int>(type: "int", nullable: true),
                    SeenCount = table.Column<int>(type: "int", nullable: false),
                    ServiceType = table.Column<int>(type: "int", nullable: false),
                    Skills = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreateServiceVM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OtherUserProfile",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Birthdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descriptions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EduEnterDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EduExitDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    LanguageKnowing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaghTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarriedType = table.Column<int>(type: "int", nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SKILLS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Semat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnivercityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkDescriptions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkEnterDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkExitDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherUserProfile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceListVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryImageAddres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentCount = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsLiked = table.Column<bool>(type: "bit", nullable: false),
                    LikeCount = table.Column<int>(type: "int", nullable: false),
                    SeenCount = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserImageAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                value: new DateTime(2020, 9, 6, 10, 46, 27, 40, DateTimeKind.Local).AddTicks(6490));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 6, 10, 46, 27, 45, DateTimeKind.Local).AddTicks(1378));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 6, 10, 46, 27, 45, DateTimeKind.Local).AddTicks(1492));
        }
    }
}
