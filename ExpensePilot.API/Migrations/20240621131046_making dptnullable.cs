using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpensePilot.API.Migrations
{
    /// <inheritdoc />
    public partial class makingdptnullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblEPUsers_tblEPDepartments_DepartmentID",
                table: "tblEPUsers");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerID",
                table: "tblEPUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentID",
                table: "tblEPUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_tblEPUsers_tblEPDepartments_DepartmentID",
                table: "tblEPUsers",
                column: "DepartmentID",
                principalTable: "tblEPDepartments",
                principalColumn: "DptID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblEPUsers_tblEPDepartments_DepartmentID",
                table: "tblEPUsers");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerID",
                table: "tblEPUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentID",
                table: "tblEPUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tblEPUsers_tblEPDepartments_DepartmentID",
                table: "tblEPUsers",
                column: "DepartmentID",
                principalTable: "tblEPDepartments",
                principalColumn: "DptID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
