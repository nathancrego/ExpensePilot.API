using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpensePilot.API.Migrations
{
    /// <inheritdoc />
    public partial class useraccesstable : Migration
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
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_tblEPUserAccess_tblEPUserRoles_UserRoleID",
                table: "tblEPUserAccess",
                column: "UserRoleID",
                principalTable: "tblEPUserRoles",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddForeignKey(
                name: "FK_tblEPUserAccess_tblEPUserRoles_UserRoleID",
                table: "tblEPUserAccess",
                column: "UserRoleID",
                principalTable: "tblEPUserRoles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
