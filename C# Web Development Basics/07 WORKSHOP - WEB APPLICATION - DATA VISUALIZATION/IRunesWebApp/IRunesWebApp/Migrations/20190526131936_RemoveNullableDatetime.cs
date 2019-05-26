using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRunesWebApp.Migrations
{
    public partial class RemoveNullableDatetime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "Users",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "Users",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
