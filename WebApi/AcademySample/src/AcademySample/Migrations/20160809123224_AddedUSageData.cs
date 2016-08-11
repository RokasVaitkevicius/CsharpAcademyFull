using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcademySample.Migrations
{
    public partial class AddedUSageData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsageDatas",
                columns: table => new
                {
                    UsageDataId = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    AvailableDiskSpace = table.Column<int>(nullable: false),
                    ComputerName = table.Column<string>(nullable: true),
                    CpuUsage = table.Column<int>(nullable: false),
                    MemoryUsage = table.Column<int>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsageDatas", x => x.UsageDataId);
                    table.ForeignKey(
                        name: "FK_UsageDatas_ComputerDetails_ComputerName",
                        column: x => x.ComputerName,
                        principalTable: "ComputerDetails",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsageDatas_ComputerName",
                table: "UsageDatas",
                column: "ComputerName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsageDatas");
        }
    }
}
