using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MentalToHell.Data.Migrations
{
    public partial class user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUser");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "UserPersonalStates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nicname",
                table: "AspNetUsers",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserPersonalStateId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserPersonalStateId",
                table: "AspNetUsers",
                column: "UserPersonalStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserPersonalStates_UserPersonalStateId",
                table: "AspNetUsers",
                column: "UserPersonalStateId",
                principalTable: "UserPersonalStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserPersonalStates_UserPersonalStateId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserPersonalStateId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "UserPersonalStates");

            migrationBuilder.DropColumn(
                name: "Nicname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserPersonalStateId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Nicname = table.Column<string>(maxLength: 100, nullable: false),
                    UserPersonalStateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUser_UserPersonalStates_UserPersonalStateId",
                        column: x => x.UserPersonalStateId,
                        principalTable: "UserPersonalStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_UserPersonalStateId",
                table: "AppUser",
                column: "UserPersonalStateId");
        }
    }
}
