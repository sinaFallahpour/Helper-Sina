using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class serviceCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

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
                    SerialNumber = table.Column<string>(nullable: true),
                    AcceptRules = table.Column<bool>(nullable: false),
                    PhotoAddress = table.Column<string>(nullable: true),
                    CreatedAdminId = table.Column<string>(nullable: true),
                    PlanId = table.Column<int>(nullable: false),
                    PlanExpDate = table.Column<DateTime>(nullable: false),
                    PlanCount = table.Column<int>(nullable: false),
                    IsUsedFree = table.Column<bool>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "TBL_Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_City",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_MonyUnit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_MonyUnit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_NewsArticleVideo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 2000, nullable: false),
                    CreateDate = table.Column<string>(nullable: true),
                    LikesCount = table.Column<int>(nullable: false),
                    CommentsCount = table.Column<int>(nullable: false),
                    SeenCount = table.Column<int>(nullable: false),
                    NewsType = table.Column<int>(nullable: false),
                    ArticlePhotoAddress = table.Column<string>(nullable: true),
                    VideoAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_NewsArticleVideo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_Plans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    ServiceCount = table.Column<int>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    IsFree = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(maxLength: 220, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Plans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_Settings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_Sliders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 550, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    PhotoAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Sliders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "TBL_EducationalHistory",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    MaghTa = table.Column<string>(nullable: true),
                    UnivercityName = table.Column<string>(nullable: true),
                    EnterDate = table.Column<string>(nullable: true),
                    ExitDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_EducationalHistory", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_TBL_EducationalHistory_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_UserSeenProfile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CurrentUserId = table.Column<string>(nullable: true),
                    SeenerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_UserSeenProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_UserSeenProfile_AspNetUsers_CurrentUserId",
                        column: x => x.CurrentUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBL_UserSeenProfile_AspNetUsers_SeenerId",
                        column: x => x.SeenerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBL_WorkExperience",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    CompanyName = table.Column<string>(maxLength: 50, nullable: true),
                    Semat = table.Column<string>(maxLength: 50, nullable: true),
                    EnterDate = table.Column<string>(maxLength: 50, nullable: true),
                    ExitDate = table.Column<string>(maxLength: 50, nullable: true),
                    Descriptions = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_WorkExperience", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_TBL_WorkExperience_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_Service",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Skills = table.Column<string>(nullable: true),
                    ServiceType = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    SendType = table.Column<int>(nullable: false),
                    IsAgreement = table.Column<bool>(nullable: false),
                    LikeCount = table.Column<int>(nullable: false),
                    CommentCount = table.Column<int>(nullable: false),
                    SeenCount = table.Column<int>(nullable: false),
                    IsSendByEmail = table.Column<bool>(nullable: false),
                    IsSendByNOtification = table.Column<bool>(nullable: false),
                    IsSendBySms = table.Column<bool>(nullable: false),
                    MinpRice = table.Column<int>(nullable: false),
                    MaxPrice = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    MonyUnitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Service", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_Service_TBL_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "TBL_Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBL_Service_TBL_City_CityId",
                        column: x => x.CityId,
                        principalTable: "TBL_City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBL_Service_TBL_MonyUnit_MonyUnitId",
                        column: x => x.MonyUnitId,
                        principalTable: "TBL_MonyUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBL_Service_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBL_NewsComment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(maxLength: 1500, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    NewsId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_NewsComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_NewsComment_TBL_NewsArticleVideo_NewsId",
                        column: x => x.NewsId,
                        principalTable: "TBL_NewsArticleVideo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBL_NewsComment_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBL_NewsLike",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrateDate = table.Column<DateTime>(nullable: false),
                    NewsId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_NewsLike", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_NewsLike_TBL_NewsArticleVideo_NewsId",
                        column: x => x.NewsId,
                        principalTable: "TBL_NewsArticleVideo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBL_NewsLike_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBL_Plane_MonyUnit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanId = table.Column<int>(nullable: true),
                    MonyUnitId = table.Column<int>(nullable: true),
                    MonyName = table.Column<string>(nullable: true),
                    IsEnabled = table.Column<bool>(nullable: false),
                    Price = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Plane_MonyUnit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_Plane_MonyUnit_TBL_MonyUnit_MonyUnitId",
                        column: x => x.MonyUnitId,
                        principalTable: "TBL_MonyUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBL_Plane_MonyUnit_TBL_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "TBL_Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBL_UserCommentService",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(maxLength: 1500, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    ServiceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_UserCommentService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_UserCommentService_TBL_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "TBL_Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBL_UserCommentService_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBL_UserLikeSerive",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    ServiceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_UserLikeSerive", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_UserLikeSerive_TBL_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "TBL_Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBL_UserLikeSerive_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TBL_Settings",
                columns: new[] { "Id", "CreatedAt", "Key", "UpdatedAt", "Value" },
                values: new object[] { 1, new DateTime(2020, 8, 22, 11, 12, 58, 314, DateTimeKind.Local).AddTicks(5151), "AboutUs", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "" });

            migrationBuilder.InsertData(
                table: "TBL_Settings",
                columns: new[] { "Id", "CreatedAt", "Key", "UpdatedAt", "Value" },
                values: new object[] { 2, new DateTime(2020, 8, 22, 11, 12, 58, 317, DateTimeKind.Local).AddTicks(1834), "Contactus", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "" });

            migrationBuilder.InsertData(
                table: "TBL_Settings",
                columns: new[] { "Id", "CreatedAt", "Key", "UpdatedAt", "Value" },
                values: new object[] { 3, new DateTime(2020, 8, 22, 11, 12, 58, 317, DateTimeKind.Local).AddTicks(1889), "SiteRules", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CreatedAdminId",
                table: "AspNetUsers",
                column: "CreatedAdminId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_NewsComment_NewsId",
                table: "TBL_NewsComment",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_NewsComment_UserId",
                table: "TBL_NewsComment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_NewsLike_NewsId",
                table: "TBL_NewsLike",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_NewsLike_UserId",
                table: "TBL_NewsLike",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_Plane_MonyUnit_MonyUnitId",
                table: "TBL_Plane_MonyUnit",
                column: "MonyUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_Plane_MonyUnit_PlanId",
                table: "TBL_Plane_MonyUnit",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_Service_CategoryId",
                table: "TBL_Service",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_Service_CityId",
                table: "TBL_Service",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_Service_MonyUnitId",
                table: "TBL_Service",
                column: "MonyUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_Service_UserId",
                table: "TBL_Service",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_UserCommentService_ServiceId",
                table: "TBL_UserCommentService",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_UserCommentService_UserId",
                table: "TBL_UserCommentService",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_UserLikeSerive_ServiceId",
                table: "TBL_UserLikeSerive",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_UserLikeSerive_UserId",
                table: "TBL_UserLikeSerive",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_UserSeenProfile_CurrentUserId",
                table: "TBL_UserSeenProfile",
                column: "CurrentUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_UserSeenProfile_SeenerId",
                table: "TBL_UserSeenProfile",
                column: "SeenerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "TBL_BankInfo");

            migrationBuilder.DropTable(
                name: "TBL_EducationalHistory");

            migrationBuilder.DropTable(
                name: "TBL_NewsComment");

            migrationBuilder.DropTable(
                name: "TBL_NewsLike");

            migrationBuilder.DropTable(
                name: "TBL_Plane_MonyUnit");

            migrationBuilder.DropTable(
                name: "TBL_Settings");

            migrationBuilder.DropTable(
                name: "TBL_Sliders");

            migrationBuilder.DropTable(
                name: "TBL_UserCommentService");

            migrationBuilder.DropTable(
                name: "TBL_UserLikeSerive");

            migrationBuilder.DropTable(
                name: "TBL_UserSeenProfile");

            migrationBuilder.DropTable(
                name: "TBL_WorkExperience");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "TBL_NewsArticleVideo");

            migrationBuilder.DropTable(
                name: "TBL_Plans");

            migrationBuilder.DropTable(
                name: "TBL_Service");

            migrationBuilder.DropTable(
                name: "TBL_Category");

            migrationBuilder.DropTable(
                name: "TBL_City");

            migrationBuilder.DropTable(
                name: "TBL_MonyUnit");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
