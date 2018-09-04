using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreTutorials.Migrations
{
    public partial class SecondSchoolDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sex",
                table: "Students",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Students");
        }
    }
}
