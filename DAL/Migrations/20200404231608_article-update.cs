using Microsoft.EntityFrameworkCore.Migrations;

namespace loppinja.Migrations
{
    public partial class articleupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "Articles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Topic",
                table: "Articles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Body",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Topic",
                table: "Articles");
        }
    }
}
