using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpensePilot.API.Migrations
{
    /// <inheritdoc />
    public partial class ExpenseStatusCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblEPUserAccess_tblEPUserRoles_UserRoleID",
                table: "tblEPUserAccess");

            migrationBuilder.AlterColumn<int>(
                name: "UserRoleID",
                table: "tblEPUserAccess",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResetPasswordToken",
                table: "tblEPLogin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ResetPasswordTokenExpiry",
                table: "tblEPLogin",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "tblEPInvoiceReceipt",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExpenseStatusID",
                table: "tblEPExpenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tblEPExpenseStatus",
                columns: table => new
                {
                    StatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEPExpenseStatus", x => x.StatusID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblEPExpenses_ExpenseStatusID",
                table: "tblEPExpenses",
                column: "ExpenseStatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblEPExpenses_tblEPExpenseStatus_ExpenseStatusID",
                table: "tblEPExpenses",
                column: "ExpenseStatusID",
                principalTable: "tblEPExpenseStatus",
                principalColumn: "StatusID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblEPUserAccess_tblEPUserRoles_UserRoleID",
                table: "tblEPUserAccess",
                column: "UserRoleID",
                principalTable: "tblEPUserRoles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblEPExpenses_tblEPExpenseStatus_ExpenseStatusID",
                table: "tblEPExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_tblEPUserAccess_tblEPUserRoles_UserRoleID",
                table: "tblEPUserAccess");

            migrationBuilder.DropTable(
                name: "tblEPExpenseStatus");

            migrationBuilder.DropIndex(
                name: "IX_tblEPExpenses_ExpenseStatusID",
                table: "tblEPExpenses");

            migrationBuilder.DropColumn(
                name: "ResetPasswordToken",
                table: "tblEPLogin");

            migrationBuilder.DropColumn(
                name: "ResetPasswordTokenExpiry",
                table: "tblEPLogin");

            migrationBuilder.DropColumn(
                name: "ExpenseStatusID",
                table: "tblEPExpenses");

            migrationBuilder.AlterColumn<int>(
                name: "UserRoleID",
                table: "tblEPUserAccess",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "tblEPInvoiceReceipt",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_tblEPUserAccess_tblEPUserRoles_UserRoleID",
                table: "tblEPUserAccess",
                column: "UserRoleID",
                principalTable: "tblEPUserRoles",
                principalColumn: "ID");
        }
    }
}
