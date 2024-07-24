using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpensePilot.API.Migrations
{
    /// <inheritdoc />
    public partial class addingofexpensemodule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblEPExpenseCategory",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEPExpenseCategory", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "tblEPInvoiceReceipt",
                columns: table => new
                {
                    ReceiptID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiptName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEPInvoiceReceipt", x => x.ReceiptID);
                });

            migrationBuilder.CreateTable(
                name: "tblEPExpenses",
                columns: table => new
                {
                    ExpenseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpenseDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpenseCategoryID = table.Column<int>(type: "int", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceVendorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    InvoiceReceiptID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEPExpenses", x => x.ExpenseID);
                    table.ForeignKey(
                        name: "FK_tblEPExpenses_tblEPExpenseCategory_ExpenseCategoryID",
                        column: x => x.ExpenseCategoryID,
                        principalTable: "tblEPExpenseCategory",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblEPExpenses_tblEPInvoiceReceipt_InvoiceReceiptID",
                        column: x => x.InvoiceReceiptID,
                        principalTable: "tblEPInvoiceReceipt",
                        principalColumn: "ReceiptID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblEPExpenses_tblEPUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "tblEPUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblEPExpenses_ExpenseCategoryID",
                table: "tblEPExpenses",
                column: "ExpenseCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_tblEPExpenses_InvoiceReceiptID",
                table: "tblEPExpenses",
                column: "InvoiceReceiptID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblEPExpenses_UserID",
                table: "tblEPExpenses",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblEPExpenses");

            migrationBuilder.DropTable(
                name: "tblEPExpenseCategory");

            migrationBuilder.DropTable(
                name: "tblEPInvoiceReceipt");
        }
    }
}
