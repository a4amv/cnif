using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobFairInformationForm.Migrations
{
    public partial class addnotefield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NoteString",
                table: "InformationForm",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoteString",
                table: "InformationForm");
        }
    }
}
