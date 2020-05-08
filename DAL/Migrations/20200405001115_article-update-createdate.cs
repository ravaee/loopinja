using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace loppinja.Migrations
{
    public partial class articleupdatecreatedate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersianDate",
                table: "Articles");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Articles");

            migrationBuilder.AddColumn<DateTime>(
                name: "PersianDate",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
