using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobFairInformationForm.Migrations
{
    public partial class tel_number_string : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "InformationForm",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "InformationForm",
                nullable: false);
        }
    }
}
