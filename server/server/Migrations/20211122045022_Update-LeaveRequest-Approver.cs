using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class UpdateLeaveRequestApprover : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Status",
                table: "LeaveRequests");

            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "LeaveRequests",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateActioned",
                table: "LeaveRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 22, 11, 50, 21, 35, DateTimeKind.Local).AddTicks(9369), new DateTime(2021, 11, 22, 11, 50, 21, 37, DateTimeKind.Local).AddTicks(2978) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 22, 11, 50, 21, 38, DateTimeKind.Local).AddTicks(8706), new DateTime(2021, 11, 22, 11, 50, 21, 38, DateTimeKind.Local).AddTicks(8724) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approved",
                table: "LeaveRequests");

            migrationBuilder.DropColumn(
                name: "DateActioned",
                table: "LeaveRequests");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "LeaveRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 19, 23, 55, 44, 385, DateTimeKind.Local).AddTicks(7333), new DateTime(2021, 11, 19, 23, 55, 44, 387, DateTimeKind.Local).AddTicks(825) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 19, 23, 55, 44, 388, DateTimeKind.Local).AddTicks(6280), new DateTime(2021, 11, 19, 23, 55, 44, 388, DateTimeKind.Local).AddTicks(6300) });

            migrationBuilder.InsertData(
                table: "LeaveRequests",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "FromDate", "Reason", "RequestedById", "Status", "ToDate", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2021, 11, 19, 23, 55, 44, 389, DateTimeKind.Local).AddTicks(2716), 2, new DateTime(2021, 11, 19, 23, 55, 44, 388, DateTimeKind.Local).AddTicks(8638), null, 1, 1, new DateTime(2021, 11, 22, 23, 55, 44, 388, DateTimeKind.Local).AddTicks(9507), new DateTime(2021, 11, 19, 23, 55, 44, 389, DateTimeKind.Local).AddTicks(3472) });
        }
    }
}
