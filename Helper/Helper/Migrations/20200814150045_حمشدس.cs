using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.Migrations
{
    public partial class حمشدس : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_Plans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ServiceCount = table.Column<int>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Plans", x => x.Id);
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
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Plane_MonyUnit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_Plane_MonyUnit_TBL_MonyUnit_MonyUnitId",
                        column: x => x.MonyUnitId,
                        principalTable: "TBL_MonyUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBL_Plane_MonyUnit_TBL_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "TBL_Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_TBL_Plane_MonyUnit_MonyUnitId",
                table: "TBL_Plane_MonyUnit",
                column: "MonyUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_Plane_MonyUnit_PlanId",
                table: "TBL_Plane_MonyUnit",
                column: "PlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_Plane_MonyUnit");

            migrationBuilder.DropTable(
                name: "TBL_Plans");

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 14, 5, 54, 45, 817, DateTimeKind.Local).AddTicks(5275));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 14, 5, 54, 45, 821, DateTimeKind.Local).AddTicks(2688));

            migrationBuilder.UpdateData(
                table: "TBL_Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 14, 5, 54, 45, 821, DateTimeKind.Local).AddTicks(2756));
        }
    }
}
