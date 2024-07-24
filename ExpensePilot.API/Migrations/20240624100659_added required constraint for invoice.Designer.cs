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
    [Migration("20240624100659_added required constraint for invoice")]
    partial class addedrequiredconstraintforinvoice
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

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

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

                    b.Property<int?>("DepartmentID")
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

                    b.Property<int?>("ManagerID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("tblEPUsers");
                });

            modelBuilder.Entity("ExpensePilot.API.Models.Domain.Expense.ExpenseCategory", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.HasKey("CategoryID");

                    b.ToTable("tblEPExpenseCategory");
                });

            modelBuilder.Entity("ExpensePilot.API.Models.Domain.Expense.Expenses", b =>
                {
                    b.Property<int>("ExpenseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExpenseID"));

                    b.Property<int>("ExpenseCategoryID")
                        .HasColumnType("int");

                    b.Property<string>("ExpenseDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExpenseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvoiceNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InvoiceReceiptID")
                        .HasColumnType("int");

                    b.Property<string>("InvoiceVendorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("float");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ExpenseID");

                    b.HasIndex("ExpenseCategoryID");

                    b.HasIndex("InvoiceReceiptID")
                        .IsUnique();

                    b.HasIndex("UserID");

                    b.ToTable("tblEPExpenses");
                });

            modelBuilder.Entity("ExpensePilot.API.Models.Domain.Expense.InvoiceReceipt", b =>
                {
                    b.Property<int>("ReceiptID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReceiptID"));

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReceiptName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReceiptID");

                    b.ToTable("tblEPInvoiceReceipt");
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
                        .HasForeignKey("DepartmentID");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("ExpensePilot.API.Models.Domain.Expense.Expenses", b =>
                {
                    b.HasOne("ExpensePilot.API.Models.Domain.Expense.ExpenseCategory", "ExpenseCategory")
                        .WithMany("tblEPExpenses")
                        .HasForeignKey("ExpenseCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExpensePilot.API.Models.Domain.Expense.InvoiceReceipt", "InvoiceReceipt")
                        .WithOne("Expense")
                        .HasForeignKey("ExpensePilot.API.Models.Domain.Expense.Expenses", "InvoiceReceiptID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExpensePilot.API.Models.Domain.Administration.UserManagement.Users", "User")
                        .WithMany("tblEPExpenses")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExpenseCategory");

                    b.Navigation("InvoiceReceipt");

                    b.Navigation("User");
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

                    b.Navigation("tblEPExpenses");

                    b.Navigation("tblEPUserAccess");
                });

            modelBuilder.Entity("ExpensePilot.API.Models.Domain.Expense.ExpenseCategory", b =>
                {
                    b.Navigation("tblEPExpenses");
                });

            modelBuilder.Entity("ExpensePilot.API.Models.Domain.Expense.InvoiceReceipt", b =>
                {
                    b.Navigation("Expense")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
