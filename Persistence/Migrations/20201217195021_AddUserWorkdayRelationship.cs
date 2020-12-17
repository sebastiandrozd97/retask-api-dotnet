using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddUserWorkdayRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Workdays",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workdays_AppUserId",
                table: "Workdays",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workdays_AspNetUsers_AppUserId",
                table: "Workdays",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workdays_AspNetUsers_AppUserId",
                table: "Workdays");

            migrationBuilder.DropIndex(
                name: "IX_Workdays_AppUserId",
                table: "Workdays");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Workdays");
        }
    }
}
