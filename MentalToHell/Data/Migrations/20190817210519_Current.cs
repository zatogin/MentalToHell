using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MentalToHell.Data.Migrations
{
    public partial class Current : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrentStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StatusName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GenderName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Religions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReligionType = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Religions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sexes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SexName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Temperaments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TemperamentName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperaments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobSatisfactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    JobSatisfactionText = table.Column<string>(maxLength: 1000, nullable: false),
                    CurrentStatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSatisfactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobSatisfactions_CurrentStatuses_CurrentStatusId",
                        column: x => x.CurrentStatusId,
                        principalTable: "CurrentStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PersonalLyfeJoys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LifeJoyExpl = table.Column<string>(maxLength: 1000, nullable: false),
                    CurrentStatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalLyfeJoys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalLyfeJoys_CurrentStatuses_CurrentStatusId",
                        column: x => x.CurrentStatusId,
                        principalTable: "CurrentStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UserPersonalStates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SexId = table.Column<int>(nullable: false),
                    GenderId = table.Column<int>(nullable: false),
                    PersonalLyfeJoyId = table.Column<int>(nullable: false),
                    JobPosition = table.Column<string>(maxLength: 100, nullable: false),
                    JobPlace = table.Column<string>(maxLength: 100, nullable: false),
                    JobSatisfactionId = table.Column<int>(nullable: false),
                    ReligionId = table.Column<int>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false),
                    AttitudeToLife = table.Column<string>(maxLength: 1000, nullable: false),
                    Credo = table.Column<string>(maxLength: 1000, nullable: false),
                    Character = table.Column<string>(maxLength: 1000, nullable: false),
                    TemperamentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPersonalStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPersonalStates_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserPersonalStates_JobSatisfactions_JobSatisfactionId",
                        column: x => x.JobSatisfactionId,
                        principalTable: "JobSatisfactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserPersonalStates_PersonalLyfeJoys_PersonalLyfeJoyId",
                        column: x => x.PersonalLyfeJoyId,
                        principalTable: "PersonalLyfeJoys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserPersonalStates_Religions_ReligionId",
                        column: x => x.ReligionId,
                        principalTable: "Religions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserPersonalStates_Sexes_SexId",
                        column: x => x.SexId,
                        principalTable: "Sexes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserPersonalStates_Temperaments_TemperamentId",
                        column: x => x.TemperamentId,
                        principalTable: "Temperaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nicname = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_UserPersonalStateId",
                table: "AppUser",
                column: "UserPersonalStateId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSatisfactions_CurrentStatusId",
                table: "JobSatisfactions",
                column: "CurrentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalLyfeJoys_CurrentStatusId",
                table: "PersonalLyfeJoys",
                column: "CurrentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPersonalStates_GenderId",
                table: "UserPersonalStates",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPersonalStates_JobSatisfactionId",
                table: "UserPersonalStates",
                column: "JobSatisfactionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPersonalStates_PersonalLyfeJoyId",
                table: "UserPersonalStates",
                column: "PersonalLyfeJoyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPersonalStates_ReligionId",
                table: "UserPersonalStates",
                column: "ReligionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPersonalStates_SexId",
                table: "UserPersonalStates",
                column: "SexId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPersonalStates_TemperamentId",
                table: "UserPersonalStates",
                column: "TemperamentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUser");

            migrationBuilder.DropTable(
                name: "UserPersonalStates");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "JobSatisfactions");

            migrationBuilder.DropTable(
                name: "PersonalLyfeJoys");

            migrationBuilder.DropTable(
                name: "Religions");

            migrationBuilder.DropTable(
                name: "Sexes");

            migrationBuilder.DropTable(
                name: "Temperaments");

            migrationBuilder.DropTable(
                name: "CurrentStatuses");
        }
    }
}
