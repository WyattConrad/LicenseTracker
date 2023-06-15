using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LicenseTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUser_Application_ApplicationsId",
                table: "ApplicationUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUser_User_UsersId",
                table: "ApplicationUser");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "ApplicationUser",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ApplicationsId",
                table: "ApplicationUser",
                newName: "ApplicationId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUser_UsersId",
                table: "ApplicationUser",
                newName: "IX_ApplicationUser_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUser_Application_ApplicationId",
                table: "ApplicationUser",
                column: "ApplicationId",
                principalTable: "Application",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUser_User_UserId",
                table: "ApplicationUser",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUser_Application_ApplicationId",
                table: "ApplicationUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUser_User_UserId",
                table: "ApplicationUser");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ApplicationUser",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "ApplicationId",
                table: "ApplicationUser",
                newName: "ApplicationsId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUser_UserId",
                table: "ApplicationUser",
                newName: "IX_ApplicationUser_UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUser_Application_ApplicationsId",
                table: "ApplicationUser",
                column: "ApplicationsId",
                principalTable: "Application",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUser_User_UsersId",
                table: "ApplicationUser",
                column: "UsersId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
