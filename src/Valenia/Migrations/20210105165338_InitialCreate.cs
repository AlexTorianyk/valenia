using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Valenia.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Visas",
                columns: table => new
                {
                    VisaId = table.Column<Guid>(nullable: false),
                    Id_Value = table.Column<Guid>(nullable: true),
                    Goal_Value = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    ExpectedProcessingTime_Days = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visas", x => x.VisaId);
                });

            migrationBuilder.CreateTable(
                name: "Requirements",
                columns: table => new
                {
                    RequirementId = table.Column<Guid>(nullable: false),
                    Name_Value = table.Column<string>(nullable: true),
                    Description_Value = table.Column<string>(nullable: true),
                    Example_Value = table.Column<string>(nullable: true),
                    ParentId_Value = table.Column<Guid>(nullable: true),
                    VisaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requirements", x => x.RequirementId);
                    table.ForeignKey(
                        name: "FK_Requirements_Visas_VisaId",
                        column: x => x.VisaId,
                        principalTable: "Visas",
                        principalColumn: "VisaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requirements_VisaId",
                table: "Requirements",
                column: "VisaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requirements");

            migrationBuilder.DropTable(
                name: "Visas");
        }
    }
}
