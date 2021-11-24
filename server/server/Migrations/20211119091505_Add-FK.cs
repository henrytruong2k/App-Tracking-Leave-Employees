using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class AddFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApproverId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ApproverId", "CreatedAt", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2021, 11, 19, 16, 15, 4, 895, DateTimeKind.Local).AddTicks(5431), new DateTime(2021, 11, 19, 16, 15, 4, 896, DateTimeKind.Local).AddTicks(9188) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ApproverId", "CreatedAt", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2021, 11, 19, 16, 15, 4, 898, DateTimeKind.Local).AddTicks(5806), new DateTime(2021, 11, 19, 16, 15, 4, 898, DateTimeKind.Local).AddTicks(5833) });

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
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 19, 15, 59, 10, 843, DateTimeKind.Local).AddTicks(5503), new DateTime(2021, 11, 19, 15, 59, 10, 845, DateTimeKind.Local).AddTicks(2960) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 19, 15, 59, 10, 847, DateTimeKind.Local).AddTicks(189), new DateTime(2021, 11, 19, 15, 59, 10, 847, DateTimeKind.Local).AddTicks(209) });
        }
    }
}
