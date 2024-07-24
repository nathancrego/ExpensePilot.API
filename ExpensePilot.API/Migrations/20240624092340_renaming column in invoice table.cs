using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpensePilot.API.Migrations
{
    /// <inheritdoc />
    public partial class renamingcolumnininvoicetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Path",
                table: "tblEPInvoiceReceipt",
                newName: "FilePath");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "tblEPInvoiceReceipt",
                newName: "Path");
        }
    }
}
