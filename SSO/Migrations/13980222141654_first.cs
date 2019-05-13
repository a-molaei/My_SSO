using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SSO.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "SSO");

            migrationBuilder.CreateTable(
                name: "Actions",
                schema: "SSO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Application",
                schema: "SSO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleGroups",
                schema: "SSO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SecurityLevels",
                schema: "SSO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SecurityModes",
                schema: "SSO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityModes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                schema: "SSO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaxFailedPasswordCount = table.Column<int>(nullable: false),
                    LockOutDuration = table.Column<int>(nullable: false),
                    TokenExpirationDuration = table.Column<int>(nullable: false),
                    PasswordExpirationDuration = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "SSO",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 128, nullable: false),
                    UserName = table.Column<string>(maxLength: 10, nullable: true),
                    Password = table.Column<string>(nullable: true),
                    PersonId = table.Column<int>(nullable: true),
                    IsLocked = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(maxLength: 128, nullable: true),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    LockOutEnabled = table.Column<bool>(nullable: false),
                    LockOutEndDate = table.Column<DateTime>(nullable: true),
                    LastPasswordChangeDateTime = table.Column<DateTime>(nullable: true),
                    ForcePasswordChangeDateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "SSO",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 128, nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    RoleGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_RoleGroups_RoleGroupId",
                        column: x => x.RoleGroupId,
                        principalSchema: "SSO",
                        principalTable: "RoleGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SecurityLevelMode",
                schema: "SSO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SecurityLevelId = table.Column<int>(nullable: false),
                    SecurityModeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityLevelMode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecurityLevelMode_SecurityLevels_SecurityLevelId",
                        column: x => x.SecurityLevelId,
                        principalSchema: "SSO",
                        principalTable: "SecurityLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SecurityLevelMode_SecurityModes_SecurityModeId",
                        column: x => x.SecurityModeId,
                        principalSchema: "SSO",
                        principalTable: "SecurityModes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HardwareTokenCodes",
                schema: "SSO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OTP = table.Column<string>(maxLength: 4, nullable: true),
                    IsVerified = table.Column<bool>(nullable: false),
                    CreationDateTime = table.Column<DateTime>(nullable: false),
                    CreatedByUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardwareTokenCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HardwareTokenCodes_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "SSO",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhoneVerificationCodes",
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
                    table.PrimaryKey("PK_PhoneVerificationCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneVerificationCodes_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "SSO",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                schema: "SSO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Token = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(maxLength: 128, nullable: true),
                    CreationDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "SSO",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRestrictedIps",
                schema: "SSO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ip = table.Column<string>(maxLength: 50, nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRestrictedIps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRestrictedIps_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "SSO",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleActions",
                schema: "SSO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(maxLength: 128, nullable: true),
                    ActionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleActions_Actions_ActionId",
                        column: x => x.ActionId,
                        principalSchema: "SSO",
                        principalTable: "Actions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleActions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "SSO",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleApplications",
                schema: "SSO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(maxLength: 128, nullable: true),
                    ApplicationId = table.Column<int>(nullable: false),
                    IsDefaultRole = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleApplications_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "SSO",
                        principalTable: "Application",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleApplications_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "SSO",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "SSO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(maxLength: 128, nullable: true),
                    RoleId = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "SSO",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "SSO",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HardwareTokenCodes_CreatedByUserId",
                schema: "SSO",
                table: "HardwareTokenCodes",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneVerificationCodes_CreatedByUserId",
                schema: "SSO",
                table: "PhoneVerificationCodes",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleActions_ActionId",
                schema: "SSO",
                table: "RoleActions",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleActions_RoleId",
                schema: "SSO",
                table: "RoleActions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleApplications_ApplicationId",
                schema: "SSO",
                table: "RoleApplications",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleApplications_RoleId",
                schema: "SSO",
                table: "RoleApplications",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleGroupId",
                schema: "SSO",
                table: "Roles",
                column: "RoleGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityLevelMode_SecurityLevelId",
                schema: "SSO",
                table: "SecurityLevelMode",
                column: "SecurityLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityLevelMode_SecurityModeId",
                schema: "SSO",
                table: "SecurityLevelMode",
                column: "SecurityModeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_UserId",
                schema: "SSO",
                table: "Sessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRestrictedIps_UserId",
                schema: "SSO",
                table: "UserRestrictedIps",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "SSO",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                schema: "SSO",
                table: "UserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HardwareTokenCodes",
                schema: "SSO");

            migrationBuilder.DropTable(
                name: "PhoneVerificationCodes",
                schema: "SSO");

            migrationBuilder.DropTable(
                name: "RoleActions",
                schema: "SSO");

            migrationBuilder.DropTable(
                name: "RoleApplications",
                schema: "SSO");

            migrationBuilder.DropTable(
                name: "SecurityLevelMode",
                schema: "SSO");

            migrationBuilder.DropTable(
                name: "Sessions",
                schema: "SSO");

            migrationBuilder.DropTable(
                name: "Settings",
                schema: "SSO");

            migrationBuilder.DropTable(
                name: "UserRestrictedIps",
                schema: "SSO");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "SSO");

            migrationBuilder.DropTable(
                name: "Actions",
                schema: "SSO");

            migrationBuilder.DropTable(
                name: "Application",
                schema: "SSO");

            migrationBuilder.DropTable(
                name: "SecurityLevels",
                schema: "SSO");

            migrationBuilder.DropTable(
                name: "SecurityModes",
                schema: "SSO");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "SSO");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "SSO");

            migrationBuilder.DropTable(
                name: "RoleGroups",
                schema: "SSO");
        }
    }
}
