using Microsoft.EntityFrameworkCore.Migrations;

namespace MentalToHellFinal.Data.Migrations
{
    public partial class CustomUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NicName",
                table: "AspNetUsers",
                newName: "NickName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NickName",
                table: "AspNetUsers",
                newName: "NicName");
        }
    }
}
