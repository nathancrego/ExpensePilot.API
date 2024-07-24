using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpensePilot.API.Migrations
{
    /// <inheritdoc />
    public partial class correctingfewtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tblEPUsers_ManagerID",
                table: "tblEPUsers",
                column: "ManagerID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblEPUsers_tblEPUsers_ManagerID",
                table: "tblEPUsers",
                column: "ManagerID",
                principalTable: "tblEPUsers",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblEPUsers_tblEPUsers_ManagerID",
                table: "tblEPUsers");

            migrationBuilder.DropIndex(
                name: "IX_tblEPUsers_ManagerID",
                table: "tblEPUsers");
        }
    }
}
