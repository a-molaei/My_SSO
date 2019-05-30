using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SSO.Migrations
{
    public partial class AuthenticationStepAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthenticationSteps",
                schema: "SSO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    SecurityLevelId = table.Column<int>(nullable: false),
                    CreationDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthenticationSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthenticationSteps_SecurityLevels_SecurityLevelId",
                        column: x => x.SecurityLevelId,
                        principalSchema: "SSO",
                        principalTable: "SecurityLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthenticationSteps_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "SSO",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthenticationSteps_SecurityLevelId",
                schema: "SSO",
                table: "AuthenticationSteps",
                column: "SecurityLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthenticationSteps_UserId",
                schema: "SSO",
                table: "AuthenticationSteps",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthenticationSteps",
                schema: "SSO");
        }
    }
}
