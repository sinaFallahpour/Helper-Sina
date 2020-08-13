using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ddddd = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    Nickname = table.Column<string>(maxLength: 200, nullable: true),
                    Birthdate = table.Column<string>(maxLength: 50, nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    MarriedType = table.Column<int>(nullable: false),
                    LanguageKnowing = table.Column<string>(maxLength: 600, nullable: true),
                    Skils = table.Column<string>(maxLength: 600, nullable: true),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    RegistrationDateTime = table.Column<DateTime>(nullable: false),
                    Descriptions = table.Column<string>(maxLength: 1000, nullable: true),
                    City = table.Column<string>(maxLength: 100, nullable: true),
                    SiteLanguage = table.Column<int>(nullable: false),
                    BankName = table.Column<string>(nullable: true),
                    AccountOwner = table.Column<string>(nullable: true),
                    CardNumber = table.Column<string>(nullable: true),
                    ShabaNumber = table.Column<string>(nullable: true),
                    VisaNumber = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<string>(nullable: true),
                    AcceptRules = table.Column<bool>(nullable: false),
                    PhotoAddress = table.Column<string>(nullable: true),
                    CreatedAdminId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AspNetUsers_CreatedAdminId",
                        column: x => x.CreatedAdminId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
