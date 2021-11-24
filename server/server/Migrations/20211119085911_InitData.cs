using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class InitData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_ApproverId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ApproverId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ApproverId",
                table: "Employees");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "CreatedAt", "DateOfBirth", "Dayoff", "Email", "FullName", "Password", "Role", "UpdatedAt" },
                values: new object[] { 1, null, new DateTime(2021, 11, 19, 15, 59, 10, 843, DateTimeKind.Local).AddTicks(5503), null, 5, "hr@gmail.com", "Nguyen Van HR", "1234", "HR", new DateTime(2021, 11, 19, 15, 59, 10, 845, DateTimeKind.Local).AddTicks(2960) });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "CreatedAt", "DateOfBirth", "Dayoff", "Email", "FullName", "Password", "Role", "UpdatedAt" },
                values: new object[] { 2, null, new DateTime(2021, 11, 19, 15, 59, 10, 847, DateTimeKind.Local).AddTicks(189), null, 5, "emp@gmail.com", "Nguyen Van Emp", "1234", "Employee", new DateTime(2021, 11, 19, 15, 59, 10, 847, DateTimeKind.Local).AddTicks(209) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "ApproverId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ApproverId",
                table: "Employees",
                column: "ApproverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_ApproverId",
                table: "Employees",
                column: "ApproverId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
