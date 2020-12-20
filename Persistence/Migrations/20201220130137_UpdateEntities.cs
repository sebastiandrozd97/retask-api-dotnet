using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class UpdateEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notification_AspNetUsers_WorkerId",
                table: "Notification");

            migrationBuilder.DropForeignKey(
                name: "FK_Notification_Workplace_WorkplaceId",
                table: "Notification");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkdayMaterial_AspNetUsers_WorkerId",
                table: "WorkdayMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkdayMaterial_Workplace_WorkplaceId",
                table: "WorkdayMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_Workdays_Workplace_WorkplaceId",
                table: "Workdays");

            migrationBuilder.DropForeignKey(
                name: "FK_Workplace_Client_ClientId",
                table: "Workplace");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Workplace",
                table: "Workplace");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkdayMaterial",
                table: "WorkdayMaterial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notification",
                table: "Notification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Client",
                table: "Client");

            migrationBuilder.RenameTable(
                name: "Workplace",
                newName: "Workplaces");

            migrationBuilder.RenameTable(
                name: "WorkdayMaterial",
                newName: "WorkdayMaterials");

            migrationBuilder.RenameTable(
                name: "Notification",
                newName: "Notifications");

            migrationBuilder.RenameTable(
                name: "Client",
                newName: "Clients");

            migrationBuilder.RenameIndex(
                name: "IX_Workplace_ClientId",
                table: "Workplaces",
                newName: "IX_Workplaces_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkdayMaterial_WorkplaceId",
                table: "WorkdayMaterials",
                newName: "IX_WorkdayMaterials_WorkplaceId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkdayMaterial_WorkerId",
                table: "WorkdayMaterials",
                newName: "IX_WorkdayMaterials_WorkerId");

            migrationBuilder.RenameIndex(
                name: "IX_Notification_WorkplaceId",
                table: "Notifications",
                newName: "IX_Notifications_WorkplaceId");

            migrationBuilder.RenameIndex(
                name: "IX_Notification_WorkerId",
                table: "Notifications",
                newName: "IX_Notifications_WorkerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workplaces",
                table: "Workplaces",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkdayMaterials",
                table: "WorkdayMaterials",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_AspNetUsers_WorkerId",
                table: "Notifications",
                column: "WorkerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Workplaces_WorkplaceId",
                table: "Notifications",
                column: "WorkplaceId",
                principalTable: "Workplaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkdayMaterials_AspNetUsers_WorkerId",
                table: "WorkdayMaterials",
                column: "WorkerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkdayMaterials_Workplaces_WorkplaceId",
                table: "WorkdayMaterials",
                column: "WorkplaceId",
                principalTable: "Workplaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Workdays_Workplaces_WorkplaceId",
                table: "Workdays",
                column: "WorkplaceId",
                principalTable: "Workplaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Workplaces_Clients_ClientId",
                table: "Workplaces",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_AspNetUsers_WorkerId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Workplaces_WorkplaceId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkdayMaterials_AspNetUsers_WorkerId",
                table: "WorkdayMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkdayMaterials_Workplaces_WorkplaceId",
                table: "WorkdayMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_Workdays_Workplaces_WorkplaceId",
                table: "Workdays");

            migrationBuilder.DropForeignKey(
                name: "FK_Workplaces_Clients_ClientId",
                table: "Workplaces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Workplaces",
                table: "Workplaces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkdayMaterials",
                table: "WorkdayMaterials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.RenameTable(
                name: "Workplaces",
                newName: "Workplace");

            migrationBuilder.RenameTable(
                name: "WorkdayMaterials",
                newName: "WorkdayMaterial");

            migrationBuilder.RenameTable(
                name: "Notifications",
                newName: "Notification");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "Client");

            migrationBuilder.RenameIndex(
                name: "IX_Workplaces_ClientId",
                table: "Workplace",
                newName: "IX_Workplace_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkdayMaterials_WorkplaceId",
                table: "WorkdayMaterial",
                newName: "IX_WorkdayMaterial_WorkplaceId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkdayMaterials_WorkerId",
                table: "WorkdayMaterial",
                newName: "IX_WorkdayMaterial_WorkerId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_WorkplaceId",
                table: "Notification",
                newName: "IX_Notification_WorkplaceId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_WorkerId",
                table: "Notification",
                newName: "IX_Notification_WorkerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workplace",
                table: "Workplace",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkdayMaterial",
                table: "WorkdayMaterial",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notification",
                table: "Notification",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Client",
                table: "Client",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_AspNetUsers_WorkerId",
                table: "Notification",
                column: "WorkerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_Workplace_WorkplaceId",
                table: "Notification",
                column: "WorkplaceId",
                principalTable: "Workplace",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkdayMaterial_AspNetUsers_WorkerId",
                table: "WorkdayMaterial",
                column: "WorkerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkdayMaterial_Workplace_WorkplaceId",
                table: "WorkdayMaterial",
                column: "WorkplaceId",
                principalTable: "Workplace",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Workdays_Workplace_WorkplaceId",
                table: "Workdays",
                column: "WorkplaceId",
                principalTable: "Workplace",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Workplace_Client_ClientId",
                table: "Workplace",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
