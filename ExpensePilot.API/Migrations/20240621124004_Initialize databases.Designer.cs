﻿// <auto-generated />
using System;
using ExpensePilot.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExpensePilot.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240621124004_Initialize databases")]
    partial class Initializedatabases
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExpensePilot.API.Models.Domain.Administration.DepartmentManagement.Department", b =>
                {
                    b.Property<int>("DptID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DptID"));

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.HasKey("DptID");

                    b.ToTable("tblEPDepartments");
                });

            modelBuilder.Entity("ExpensePilot.API.Models.Domain.Administration.RoleAccessManagement.UserAccess", b =>
                {
                    b.Property<int>("UserAccessID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserAccessID"));

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<int>("UserRoleID")
                        .HasColumnType("int");

                    b.HasKey("UserAccessID");

                    b.HasIndex("UserID");

                    b.HasIndex("UserRoleID");

                    b.ToTable("tblEPUserAccess");
                });

            modelBuilder.Entity("ExpensePilot.API.Models.Domain.Administration.RoleAccessManagement.UserRoles", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("tblEPUserRoles");
                });

            modelBuilder.Entity("ExpensePilot.API.Models.Domain.Administration.UserManagement.Login", b =>
                {
                    b.Property<int>("LoginId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoginId"));

                    b.Property<DateTime>("DateTimeLoggedIn")
                        .HasColumnType("datetime2");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("LoginId");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("tblEPLogin");
                });

            modelBuilder.Entity("ExpensePilot.API.Models.Domain.Administration.UserManagement.Users", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Logon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ManagerID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("tblEPUsers");
                });

            modelBuilder.Entity("ExpensePilot.API.Models.Domain.Administration.RoleAccessManagement.UserAccess", b =>
                {
                    b.HasOne("ExpensePilot.API.Models.Domain.Administration.UserManagement.Users", "User")
                        .WithMany("tblEPUserAccess")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExpensePilot.API.Models.Domain.Administration.RoleAccessManagement.UserRoles", "UserRole")
                        .WithMany("tblEPUserAccess")
                        .HasForeignKey("UserRoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("ExpensePilot.API.Models.Domain.Administration.UserManagement.Login", b =>
                {
                    b.HasOne("ExpensePilot.API.Models.Domain.Administration.UserManagement.Users", "User")
                        .WithOne("Login")
                        .HasForeignKey("ExpensePilot.API.Models.Domain.Administration.UserManagement.Login", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ExpensePilot.API.Models.Domain.Administration.UserManagement.Users", b =>
                {
                    b.HasOne("ExpensePilot.API.Models.Domain.Administration.DepartmentManagement.Department", "Department")
                        .WithMany("tblEPUsers")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("ExpensePilot.API.Models.Domain.Administration.DepartmentManagement.Department", b =>
                {
                    b.Navigation("tblEPUsers");
                });

            modelBuilder.Entity("ExpensePilot.API.Models.Domain.Administration.RoleAccessManagement.UserRoles", b =>
                {
                    b.Navigation("tblEPUserAccess");
                });

            modelBuilder.Entity("ExpensePilot.API.Models.Domain.Administration.UserManagement.Users", b =>
                {
                    b.Navigation("Login")
                        .IsRequired();

                    b.Navigation("tblEPUserAccess");
                });
#pragma warning restore 612, 618
        }
    }
}
