using Microsoft.EntityFrameworkCore.Migrations;

namespace SSO.Migrations
{
    public partial class urlAddedToApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                schema: "SSO",
                table: "Application",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                schema: "SSO",
                table: "Application");
        }
    }
}
