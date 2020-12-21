using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class UpdateWorkplaceWorkdayMaterialWorkdayNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Workplaces",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Workplaces",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalInfo",
                table: "Workdays",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Workdays",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "WorkingFrom",
                table: "Workdays",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkingTo",
                table: "Workdays",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Worktime",
                table: "Workdays",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "WorkdayMaterials",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Notifications",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Workplaces");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Workplaces");

            migrationBuilder.DropColumn(
                name: "AdditionalInfo",
                table: "Workdays");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Workdays");

            migrationBuilder.DropColumn(
                name: "WorkingFrom",
                table: "Workdays");

            migrationBuilder.DropColumn(
                name: "WorkingTo",
                table: "Workdays");

            migrationBuilder.DropColumn(
                name: "Worktime",
                table: "Workdays");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "WorkdayMaterials");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Notifications");
        }
    }
}
