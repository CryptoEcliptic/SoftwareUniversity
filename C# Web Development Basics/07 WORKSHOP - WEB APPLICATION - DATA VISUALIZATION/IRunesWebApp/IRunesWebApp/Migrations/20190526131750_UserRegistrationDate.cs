using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRunesWebApp.Migrations
{
    public partial class UserRegistrationDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                table: "Users");
        }
    }
}
