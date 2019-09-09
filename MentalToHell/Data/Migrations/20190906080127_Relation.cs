using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MentalToHell.Data.Migrations
{
    public partial class Relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonalRelationDays",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    Day = table.Column<DateTime>(nullable: false),
                    Mood = table.Column<int>(nullable: false),
                    ReportMoodId = table.Column<int>(nullable: true),
                    RelationLink = table.Column<string>(maxLength: 100, nullable: false),
                    PersonalRelation = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalRelationDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalRelationDays_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonalRelationDays_ReportMoods_ReportMoodId",
                        column: x => x.ReportMoodId,
                        principalTable: "ReportMoods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonalRelationMonths",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    Day = table.Column<DateTime>(nullable: false),
                    Mood = table.Column<int>(nullable: false),
                    ReportMoodId = table.Column<int>(nullable: true),
                    RelationLink = table.Column<string>(maxLength: 100, nullable: false),
                    PersonalRelation = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalRelationMonths", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalRelationMonths_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonalRelationMonths_ReportMoods_ReportMoodId",
                        column: x => x.ReportMoodId,
                        principalTable: "ReportMoods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonalRelationWeeks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    Day = table.Column<DateTime>(nullable: false),
                    Mood = table.Column<int>(nullable: false),
                    ReportMoodId = table.Column<int>(nullable: true),
                    RelationLink = table.Column<string>(maxLength: 100, nullable: false),
                    PersonalRelation = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalRelationWeeks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalRelationWeeks_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonalRelationWeeks_ReportMoods_ReportMoodId",
                        column: x => x.ReportMoodId,
                        principalTable: "ReportMoods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonalRelationYears",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    Day = table.Column<DateTime>(nullable: false),
                    Mood = table.Column<int>(nullable: false),
                    ReportMoodId = table.Column<int>(nullable: true),
                    RelationLink = table.Column<string>(maxLength: 100, nullable: false),
                    PersonalRelation = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalRelationYears", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalRelationYears_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonalRelationYears_ReportMoods_ReportMoodId",
                        column: x => x.ReportMoodId,
                        principalTable: "ReportMoods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonalRelationDays_ApplicationUserId",
                table: "PersonalRelationDays",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalRelationDays_ReportMoodId",
                table: "PersonalRelationDays",
                column: "ReportMoodId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalRelationMonths_ApplicationUserId",
                table: "PersonalRelationMonths",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalRelationMonths_ReportMoodId",
                table: "PersonalRelationMonths",
                column: "ReportMoodId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalRelationWeeks_ApplicationUserId",
                table: "PersonalRelationWeeks",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalRelationWeeks_ReportMoodId",
                table: "PersonalRelationWeeks",
                column: "ReportMoodId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalRelationYears_ApplicationUserId",
                table: "PersonalRelationYears",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalRelationYears_ReportMoodId",
                table: "PersonalRelationYears",
                column: "ReportMoodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalRelationDays");

            migrationBuilder.DropTable(
                name: "PersonalRelationMonths");

            migrationBuilder.DropTable(
                name: "PersonalRelationWeeks");

            migrationBuilder.DropTable(
                name: "PersonalRelationYears");
        }
    }
}
