using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpensePilot.API.Migrations
{
    /// <inheritdoc />
    public partial class Initializedatabases : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblEPDepartments",
                columns: table => new
                {
                    DptID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEPDepartments", x => x.DptID);
                });

            migrationBuilder.CreateTable(
                name: "tblEPUserRoles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEPUserRoles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblEPUsers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerID = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEPUsers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblEPUsers_tblEPDepartments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "tblEPDepartments",
                        principalColumn: "DptID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblEPLogin",
                columns: table => new
                {
                    LoginId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HashedPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeLoggedIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEPLogin", x => x.LoginId);
                    table.ForeignKey(
                        name: "FK_tblEPLogin_tblEPUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "tblEPUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblEPUserAccess",
                columns: table => new
                {
                    UserAccessID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    UserRoleID = table.Column<int>(type: "int", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEPUserAccess", x => x.UserAccessID);
                    table.ForeignKey(
                        name: "FK_tblEPUserAccess_tblEPUserRoles_UserRoleID",
                        column: x => x.UserRoleID,
                        principalTable: "tblEPUserRoles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblEPUserAccess_tblEPUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "tblEPUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblEPLogin_UserID",
                table: "tblEPLogin",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblEPUserAccess_UserID",
                table: "tblEPUserAccess",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_tblEPUserAccess_UserRoleID",
                table: "tblEPUserAccess",
                column: "UserRoleID");

            migrationBuilder.CreateIndex(
                name: "IX_tblEPUsers_DepartmentID",
                table: "tblEPUsers",
                column: "DepartmentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblEPLogin");

            migrationBuilder.DropTable(
                name: "tblEPUserAccess");

            migrationBuilder.DropTable(
                name: "tblEPUserRoles");

            migrationBuilder.DropTable(
                name: "tblEPUsers");

            migrationBuilder.DropTable(
                name: "tblEPDepartments");
        }
    }
}
