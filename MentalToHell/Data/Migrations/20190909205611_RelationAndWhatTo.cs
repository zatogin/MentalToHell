using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MentalToHell.Data.Migrations
{
    public partial class RelationAndWhatTo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WhatToStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WhatStatus = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhatToStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToThinkAbout",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    ToThinkKey = table.Column<string>(maxLength: 100, nullable: false),
                    WhatText = table.Column<string>(maxLength: 100, nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    WhatToStatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToThinkAbout", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToThinkAbout_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ToThinkAbout_WhatToStatus_WhatToStatusId",
                        column: x => x.WhatToStatusId,
                        principalTable: "WhatToStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WhatToRead",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    ToRead = table.Column<string>(maxLength: 100, nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    WhatToStatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhatToRead", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WhatToRead_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WhatToRead_WhatToStatus_WhatToStatusId",
                        column: x => x.WhatToStatusId,
                        principalTable: "WhatToStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WhatToTaste",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    ToEat = table.Column<string>(maxLength: 100, nullable: false),
                    WhereToEat = table.Column<string>(maxLength: 100, nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    WhatToStatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhatToTaste", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WhatToTaste_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WhatToTaste_WhatToStatus_WhatToStatusId",
                        column: x => x.WhatToStatusId,
                        principalTable: "WhatToStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WhatToWatch",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    ToBe = table.Column<string>(maxLength: 100, nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    WhatToStatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhatToWatch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WhatToWatch_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WhatToWatch_WhatToStatus_WhatToStatusId",
                        column: x => x.WhatToStatusId,
                        principalTable: "WhatToStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WhereToBe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    ToBe = table.Column<string>(maxLength: 100, nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    WhatToStatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhereToBe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WhereToBe_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WhereToBe_WhatToStatus_WhatToStatusId",
                        column: x => x.WhatToStatusId,
                        principalTable: "WhatToStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToThinkAbout_ApplicationUserId",
                table: "ToThinkAbout",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ToThinkAbout_WhatToStatusId",
                table: "ToThinkAbout",
                column: "WhatToStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_WhatToRead_ApplicationUserId",
                table: "WhatToRead",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WhatToRead_WhatToStatusId",
                table: "WhatToRead",
                column: "WhatToStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_WhatToTaste_ApplicationUserId",
                table: "WhatToTaste",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WhatToTaste_WhatToStatusId",
                table: "WhatToTaste",
                column: "WhatToStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_WhatToWatch_ApplicationUserId",
                table: "WhatToWatch",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WhatToWatch_WhatToStatusId",
                table: "WhatToWatch",
                column: "WhatToStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_WhereToBe_ApplicationUserId",
                table: "WhereToBe",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WhereToBe_WhatToStatusId",
                table: "WhereToBe",
                column: "WhatToStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToThinkAbout");

            migrationBuilder.DropTable(
                name: "WhatToRead");

            migrationBuilder.DropTable(
                name: "WhatToTaste");

            migrationBuilder.DropTable(
                name: "WhatToWatch");

            migrationBuilder.DropTable(
                name: "WhereToBe");

            migrationBuilder.DropTable(
                name: "WhatToStatus");
        }
    }
}
