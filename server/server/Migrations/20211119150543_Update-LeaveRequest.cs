using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class UpdateLeaveRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequests_Employees_CreatedById",
                table: "LeaveRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequests_Employees_RequestById",
                table: "LeaveRequests");

            migrationBuilder.DropColumn(
                name: "CreateById",
                table: "LeaveRequests");

            migrationBuilder.RenameColumn(
                name: "RequestById",
                table: "LeaveRequests",
                newName: "RequestedById");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveRequests_RequestById",
                table: "LeaveRequests",
                newName: "IX_LeaveRequests_RequestedById");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedById",
                table: "LeaveRequests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "ApproverId", "CreatedAt", "DateOfBirth", "Dayoff", "Email", "FullName", "Password", "Role", "UpdatedAt" },
                values: new object[] { 1, null, 1, new DateTime(2021, 11, 19, 22, 5, 41, 916, DateTimeKind.Local).AddTicks(3233), null, 5, "hr@gmail.com", "Nguyen Van HR", "1234", "HR", new DateTime(2021, 11, 19, 22, 5, 41, 918, DateTimeKind.Local).AddTicks(8719) });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "ApproverId", "CreatedAt", "DateOfBirth", "Dayoff", "Email", "FullName", "Password", "Role", "UpdatedAt" },
                values: new object[] { 2, null, 1, new DateTime(2021, 11, 19, 22, 5, 41, 922, DateTimeKind.Local).AddTicks(3180), null, 5, "emp@gmail.com", "Nguyen Van Emp", "1234", "Employee", new DateTime(2021, 11, 19, 22, 5, 41, 922, DateTimeKind.Local).AddTicks(3212) });

            migrationBuilder.InsertData(
                table: "LeaveRequests",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "FromDate", "Reason", "RequestedById", "Status", "ToDate", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2021, 11, 19, 22, 5, 41, 922, DateTimeKind.Local).AddTicks(8022), 2, new DateTime(2021, 11, 19, 22, 5, 41, 922, DateTimeKind.Local).AddTicks(5000), null, 1, 1, new DateTime(2021, 11, 22, 22, 5, 41, 922, DateTimeKind.Local).AddTicks(5587), new DateTime(2021, 11, 19, 22, 5, 41, 922, DateTimeKind.Local).AddTicks(8654) });

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequests_Employees_CreatedById",
                table: "LeaveRequests",
                column: "CreatedById",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequests_Employees_RequestedById",
                table: "LeaveRequests",
                column: "RequestedById",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequests_Employees_CreatedById",
                table: "LeaveRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequests_Employees_RequestedById",
                table: "LeaveRequests");

            migrationBuilder.DeleteData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "RequestedById",
                table: "LeaveRequests",
                newName: "RequestById");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveRequests_RequestedById",
                table: "LeaveRequests",
                newName: "IX_LeaveRequests_RequestById");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedById",
                table: "LeaveRequests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CreateById",
                table: "LeaveRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequests_Employees_CreatedById",
                table: "LeaveRequests",
                column: "CreatedById",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequests_Employees_RequestById",
                table: "LeaveRequests",
                column: "RequestById",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
