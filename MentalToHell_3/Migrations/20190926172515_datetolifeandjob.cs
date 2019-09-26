using Microsoft.EntityFrameworkCore.Migrations;

namespace MentalToHell_3.Migrations
{
    public partial class datetolifeandjob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JobDate",
                table: "LifeJoys",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "JobDate",
                table: "JobSatisfactions",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobDate",
                table: "LifeJoys");

            migrationBuilder.DropColumn(
                name: "JobDate",
                table: "JobSatisfactions");
        }
    }
}
