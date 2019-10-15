using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MentalToHellFinal.Data.Migrations
{
    public partial class FullUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "JobConclusions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationUserId = table.Column<string>(nullable: false),
                    JobConclusionHead = table.Column<string>(maxLength: 1000, nullable: false),
                    JobSatisfactionText = table.Column<string>(maxLength: 1000, nullable: false),
                    JobDate = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobConclusions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobConclusions_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LifeConclusions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationUserId = table.Column<string>(nullable: false),
                    LifeConclusionHead = table.Column<string>(maxLength: 1000, nullable: false),
                    LifeConExpl = table.Column<string>(maxLength: 1000, nullable: false),
                    LifeConDate = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LifeConclusions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LifeConclusions_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "UserCurrentStates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationUserId = table.Column<string>(nullable: false),
                    SexId = table.Column<int>(nullable: false),
                    GenderId = table.Column<int>(nullable: false),
                    TemperamentId = table.Column<int>(nullable: false),
                    Credo = table.Column<string>(maxLength: 1000, nullable: false),
                    Character = table.Column<string>(maxLength: 1000, nullable: false),
                    ReligionId = table.Column<int>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCurrentStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCurrentStates_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCurrentStates_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCurrentStates_Religions_ReligionId",
                        column: x => x.ReligionId,
                        principalTable: "Religions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCurrentStates_Sexes_SexId",
                        column: x => x.SexId,
                        principalTable: "Sexes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCurrentStates_Temperaments_TemperamentId",
                        column: x => x.TemperamentId,
                        principalTable: "Temperaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobConclusions_ApplicationUserId",
                table: "JobConclusions",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LifeConclusions_ApplicationUserId",
                table: "LifeConclusions",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCurrentStates_ApplicationUserId",
                table: "UserCurrentStates",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCurrentStates_GenderId",
                table: "UserCurrentStates",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCurrentStates_ReligionId",
                table: "UserCurrentStates",
                column: "ReligionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCurrentStates_SexId",
                table: "UserCurrentStates",
                column: "SexId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCurrentStates_TemperamentId",
                table: "UserCurrentStates",
                column: "TemperamentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobConclusions");

            migrationBuilder.DropTable(
                name: "LifeConclusions");

            migrationBuilder.DropTable(
                name: "UserCurrentStates");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Religions");

            migrationBuilder.DropTable(
                name: "Sexes");

            migrationBuilder.DropTable(
                name: "Temperaments");
        }
    }
}
