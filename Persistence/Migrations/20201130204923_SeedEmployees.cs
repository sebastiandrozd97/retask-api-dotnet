using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class SeedEmployees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "LastName", "Telephone" },
                values: new object[] { new Guid("213e5484-5f43-4187-9ef5-3afd19650ba7"), "Sebastian", "Drozd", "638334112" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "LastName", "Telephone" },
                values: new object[] { new Guid("df7df2c4-005a-4081-a272-c15d0f6fedf4"), "Artur", "Płytkowy", "698332444" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "LastName", "Telephone" },
                values: new object[] { new Guid("31052f7a-bf2a-47d5-aecb-8dde07f73795"), "Piotr", "Malowniczy", "638334112" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "LastName", "Telephone" },
                values: new object[] { new Guid("614dc48f-178e-4a2d-a9d8-81589bc64a92"), "Kamil", "Fugowy", "638334112" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "LastName", "Telephone" },
                values: new object[] { new Guid("c37008c5-34e5-43c7-9a47-3a3a7e883e14"), "Karol", "Szpachlowy", "638334112" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("213e5484-5f43-4187-9ef5-3afd19650ba7"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("31052f7a-bf2a-47d5-aecb-8dde07f73795"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("614dc48f-178e-4a2d-a9d8-81589bc64a92"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("c37008c5-34e5-43c7-9a47-3a3a7e883e14"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("df7df2c4-005a-4081-a272-c15d0f6fedf4"));
        }
    }
}
