﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SSO.Models.SsoDbContext;

namespace SSO.Migrations
{
    [DbContext(typeof(SsoDbContext))]
    [Migration("13980305165845_ChangePhoneToMobile")]
    partial class ChangePhoneToMobile
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SSO.Models.Action", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Actions","SSO");
                });

            modelBuilder.Entity("SSO.Models.Application", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Application","SSO");
                });

            modelBuilder.Entity("SSO.Models.HardwareTokenCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedByUserId");

                    b.Property<DateTime>("CreationDateTime");

                    b.Property<bool>("IsVerified");

                    b.Property<string>("OTP")
                        .HasMaxLength(4);

                    b.HasKey("Id");

                    b.HasIndex("CreatedByUserId");

                    b.ToTable("HardwareTokenCodes","SSO");
                });

            modelBuilder.Entity("SSO.Models.MobileVerificationCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<string>("CreatedByUserId");

                    b.Property<DateTime>("CreationDateTime");

                    b.Property<bool>("IsVerified");

                    b.Property<string>("MobileNumber")
                        .HasMaxLength(11);

                    b.HasKey("Id");

                    b.HasIndex("CreatedByUserId");

                    b.ToTable("MobileVerificationCodes","SSO");
                });

            modelBuilder.Entity("SSO.Models.Role", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128);

                    b.Property<int>("RoleGroupId");

                    b.Property<string>("Title")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("RoleGroupId");

                    b.ToTable("Roles","SSO");
                });

            modelBuilder.Entity("SSO.Models.RoleAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActionId");

                    b.Property<string>("RoleId")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("ActionId");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleActions","SSO");
                });

            modelBuilder.Entity("SSO.Models.RoleApplication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApplicationId");

                    b.Property<bool>("IsDefaultRole");

                    b.Property<string>("RoleId")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleApplications","SSO");
                });

            modelBuilder.Entity("SSO.Models.RoleGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("RoleGroups","SSO");
                });

            modelBuilder.Entity("SSO.Models.SecurityLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("SecurityLevels","SSO");
                });

            modelBuilder.Entity("SSO.Models.SecurityLevelMode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SecurityLevelId");

                    b.Property<int>("SecurityModeId");

                    b.HasKey("Id");

                    b.HasIndex("SecurityLevelId");

                    b.HasIndex("SecurityModeId");

                    b.ToTable("SecurityLevelMode","SSO");
                });

            modelBuilder.Entity("SSO.Models.SecurityMode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("SecurityModes","SSO");
                });

            modelBuilder.Entity("SSO.Models.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDateTime");

                    b.Property<string>("Token");

                    b.Property<string>("UserId")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Sessions","SSO");
                });

            modelBuilder.Entity("SSO.Models.Setting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LockOutDuration");

                    b.Property<int>("MaxFailedPasswordCount");

                    b.Property<int>("PasswordExpirationDuration");

                    b.Property<int>("TokenExpirationDuration");

                    b.HasKey("Id");

                    b.ToTable("Settings","SSO");
                });

            modelBuilder.Entity("SSO.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128);

                    b.Property<int>("AccessFailedCount");

                    b.Property<DateTime>("CreationDateTime");

                    b.Property<DateTime?>("ForcePasswordChangeDateTime");

                    b.Property<bool>("IsLocked");

                    b.Property<DateTime?>("LastPasswordChangeDateTime");

                    b.Property<bool>("LockOutEnabled");

                    b.Property<DateTime?>("LockOutEndDate");

                    b.Property<string>("MobileNumber")
                        .HasMaxLength(11);

                    b.Property<string>("Password");

                    b.Property<int?>("PersonId");

                    b.Property<string>("SecurityStamp")
                        .HasMaxLength(128);

                    b.Property<string>("UserName")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Users","SSO");
                });

            modelBuilder.Entity("SSO.Models.UserRestrictedIp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ip")
                        .HasMaxLength(50);

                    b.Property<bool>("IsActive");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserRestrictedIps","SSO");
                });

            modelBuilder.Entity("SSO.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleId")
                        .HasMaxLength(128);

                    b.Property<string>("UserId")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles","SSO");
                });

            modelBuilder.Entity("SSO.Models.HardwareTokenCode", b =>
                {
                    b.HasOne("SSO.Models.User", "CreatedByUser")
                        .WithMany("HardwareTokenCodes")
                        .HasForeignKey("CreatedByUserId");
                });

            modelBuilder.Entity("SSO.Models.MobileVerificationCode", b =>
                {
                    b.HasOne("SSO.Models.User", "CreatedByUser")
                        .WithMany("MobileVerificationCodes")
                        .HasForeignKey("CreatedByUserId");
                });

            modelBuilder.Entity("SSO.Models.Role", b =>
                {
                    b.HasOne("SSO.Models.RoleGroup", "RoleGroup")
                        .WithMany("Roles")
                        .HasForeignKey("RoleGroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SSO.Models.RoleAction", b =>
                {
                    b.HasOne("SSO.Models.Action", "Action")
                        .WithMany()
                        .HasForeignKey("ActionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SSO.Models.Role", "Role")
                        .WithMany("RoleActions")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("SSO.Models.RoleApplication", b =>
                {
                    b.HasOne("SSO.Models.Application", "Application")
                        .WithMany()
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SSO.Models.Role", "Role")
                        .WithMany("RoleApplications")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("SSO.Models.SecurityLevelMode", b =>
                {
                    b.HasOne("SSO.Models.SecurityLevel", "SecurityLevel")
                        .WithMany("SecurityLevelModes")
                        .HasForeignKey("SecurityLevelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SSO.Models.SecurityMode", "SecurityMode")
                        .WithMany()
                        .HasForeignKey("SecurityModeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SSO.Models.Session", b =>
                {
                    b.HasOne("SSO.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SSO.Models.UserRestrictedIp", b =>
                {
                    b.HasOne("SSO.Models.User", "User")
                        .WithMany("UserRestrictedIps")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SSO.Models.UserRole", b =>
                {
                    b.HasOne("SSO.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("SSO.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
