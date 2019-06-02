using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SSO.Migrations
{
    public partial class fixLastPasswordDateAndForcePasswordType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForcePasswordChangeDateTime",
                schema: "SSO",
                table: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastPasswordChangeDateTime",
                schema: "SSO",
                table: "Users",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ForcePasswordChange",
                schema: "SSO",
                table: "Users",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForcePasswordChange",
                schema: "SSO",
                table: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastPasswordChangeDateTime",
                schema: "SSO",
                table: "Users",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<DateTime>(
                name: "ForcePasswordChangeDateTime",
                schema: "SSO",
                table: "Users",
                nullable: true);
        }
    }
}
