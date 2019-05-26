using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SSO.Migrations
{
    public partial class ChangePhoneToMobile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneVerificationCodes",
                schema: "SSO");

            migrationBuilder.CreateTable(
                name: "MobileVerificationCodes",
                schema: "SSO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(maxLength: 11, nullable: true),
                    IsVerified = table.Column<bool>(nullable: false),
                    CreationDateTime = table.Column<DateTime>(nullable: false),
                    CreatedByUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileVerificationCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MobileVerificationCodes_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "SSO",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MobileVerificationCodes_CreatedByUserId",
                schema: "SSO",
                table: "MobileVerificationCodes",
                column: "CreatedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MobileVerificationCodes",
                schema: "SSO");

            migrationBuilder.CreateTable(
                name: "PhoneVerificationCodes",
                schema: "SSO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    CreatedByUserId = table.Column<string>(nullable: true),
                    CreationDateTime = table.Column<DateTime>(nullable: false),
                    IsVerified = table.Column<bool>(nullable: false),
                    MobileNumber = table.Column<string>(maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneVerificationCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneVerificationCodes_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "SSO",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhoneVerificationCodes_CreatedByUserId",
                schema: "SSO",
                table: "PhoneVerificationCodes",
                column: "CreatedByUserId");
        }
    }
}
