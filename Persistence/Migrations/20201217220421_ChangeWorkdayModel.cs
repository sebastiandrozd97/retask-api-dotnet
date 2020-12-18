using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class ChangeWorkdayModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workdays_AspNetUsers_AppUserId",
                table: "Workdays");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Workdays",
                newName: "WorkerId");

            migrationBuilder.RenameIndex(
                name: "IX_Workdays_AppUserId",
                table: "Workdays",
                newName: "IX_Workdays_WorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workdays_AspNetUsers_WorkerId",
                table: "Workdays",
                column: "WorkerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workdays_AspNetUsers_WorkerId",
                table: "Workdays");

            migrationBuilder.RenameColumn(
                name: "WorkerId",
                table: "Workdays",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Workdays_WorkerId",
                table: "Workdays",
                newName: "IX_Workdays_AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workdays_AspNetUsers_AppUserId",
                table: "Workdays",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
