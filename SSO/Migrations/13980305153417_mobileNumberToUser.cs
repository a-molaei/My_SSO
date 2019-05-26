using Microsoft.EntityFrameworkCore.Migrations;

namespace SSO.Migrations
{
    public partial class mobileNumberToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MobileNumber",
                schema: "SSO",
                table: "Users",
                maxLength: 11,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MobileNumber",
                schema: "SSO",
                table: "Users");
        }
    }
}
