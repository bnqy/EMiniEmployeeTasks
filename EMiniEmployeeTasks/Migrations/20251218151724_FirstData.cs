using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EMiniEmployeeTasks.Migrations
{
    /// <inheritdoc />
    public partial class FirstData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreatedAt", "Department", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Software Development", "sam.raiden@company.com", "Sam", "Raiden" },
                    { 2, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Software Development", "jana.mcleaf@company.com", "Jana", "McLeaf" },
                    { 3, new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administration", "kane.miller@company.com", "Kane", "Miller" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedAt", "Description", "EmployeeId", "IsCompleted", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Add JWT authentication to the API", 1, false, "Implement authentication" },
                    { 2, new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Resolve SQL Server migration errors", 1, true, "Fix migration issues" },
                    { 3, new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Generate monthly admin statistics", 3, false, "Prepare admin report" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
