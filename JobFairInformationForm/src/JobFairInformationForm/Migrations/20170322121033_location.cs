using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JobFairInformationForm.Migrations
{
    public partial class location : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InformationForm2Location",
                columns: table => new
                {
                    InformationFormId = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformationForm2Location", x => new { x.InformationFormId, x.LocationId });
                    table.ForeignKey(
                        name: "FK_InformationForm2Location_InformationForm_InformationFormId",
                        column: x => x.InformationFormId,
                        principalTable: "InformationForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InformationForm2Location_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InformationForm2Location_InformationFormId",
                table: "InformationForm2Location",
                column: "InformationFormId");

            migrationBuilder.CreateIndex(
                name: "IX_InformationForm2Location_LocationId",
                table: "InformationForm2Location",
                column: "LocationId");

            migrationBuilder.Sql("INSERT INTO [Location] ([Name]) VALUES ('Zlin','Prague','Bucharest', 'Bratislava')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InformationForm2Location");

            migrationBuilder.DropTable(
                name: "Location");
        }
    }
}
