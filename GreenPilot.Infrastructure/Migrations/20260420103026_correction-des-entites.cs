using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenPilot.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class correctiondesentites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HarvestEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HarvestDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Weight = table.Column<int>(type: "int", maxLength: 250, nullable: false),
                    Remark = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    FinalAdvice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RunId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HarvestEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HarvestEntity_Runs_RunId",
                        column: x => x.RunId,
                        principalTable: "Runs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HarvestEntity_RunId",
                table: "HarvestEntity",
                column: "RunId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HarvestEntity");
        }
    }
}
