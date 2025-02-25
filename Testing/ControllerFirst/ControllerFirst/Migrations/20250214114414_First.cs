using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControllerFirst.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    roleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Roles__B19478603A776CCC", x => x.roleName);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    isEmailConfirmed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    refreshToken = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__66DCF95D7E0943AE", x => x.userName);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    userRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userNameRef = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    roleNameRef = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserRole__CD3149CCDE4D7241", x => x.userRoleId);
                    table.ForeignKey(
                        name: "FK__UserRoles__roleN__2B3F6F97",
                        column: x => x.roleNameRef,
                        principalTable: "Roles",
                        principalColumn: "roleName");
                    table.ForeignKey(
                        name: "FK__UserRoles__userN__2A4B4B5E",
                        column: x => x.userNameRef,
                        principalTable: "Users",
                        principalColumn: "userName");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_roleNameRef",
                table: "UserRoles",
                column: "roleNameRef");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_userNameRef",
                table: "UserRoles",
                column: "userNameRef");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__AB6E61646FB653B8",
                table: "Users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_RefreshToken",
                table: "Users",
                column: "refreshToken",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
