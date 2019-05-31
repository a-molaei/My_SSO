using Microsoft.EntityFrameworkCore.Migrations;

namespace SSO.Migrations
{
    public partial class FixAuthStep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthenticationSteps_SecurityLevels_SecurityLevelId",
                schema: "SSO",
                table: "AuthenticationSteps");

            migrationBuilder.RenameColumn(
                name: "SecurityLevelId",
                schema: "SSO",
                table: "AuthenticationSteps",
                newName: "SecurityModeId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthenticationSteps_SecurityLevelId",
                schema: "SSO",
                table: "AuthenticationSteps",
                newName: "IX_AuthenticationSteps_SecurityModeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthenticationSteps_SecurityModes_SecurityModeId",
                schema: "SSO",
                table: "AuthenticationSteps",
                column: "SecurityModeId",
                principalSchema: "SSO",
                principalTable: "SecurityModes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthenticationSteps_SecurityModes_SecurityModeId",
                schema: "SSO",
                table: "AuthenticationSteps");

            migrationBuilder.RenameColumn(
                name: "SecurityModeId",
                schema: "SSO",
                table: "AuthenticationSteps",
                newName: "SecurityLevelId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthenticationSteps_SecurityModeId",
                schema: "SSO",
                table: "AuthenticationSteps",
                newName: "IX_AuthenticationSteps_SecurityLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthenticationSteps_SecurityLevels_SecurityLevelId",
                schema: "SSO",
                table: "AuthenticationSteps",
                column: "SecurityLevelId",
                principalSchema: "SSO",
                principalTable: "SecurityLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
