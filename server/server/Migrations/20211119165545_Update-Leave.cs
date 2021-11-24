using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class UpdateLeave : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "FromDate", "ToDate", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 19, 23, 55, 44, 389, DateTimeKind.Local).AddTicks(2716), new DateTime(2021, 11, 19, 23, 55, 44, 388, DateTimeKind.Local).AddTicks(8638), new DateTime(2021, 11, 22, 23, 55, 44, 388, DateTimeKind.Local).AddTicks(9507), new DateTime(2021, 11, 19, 23, 55, 44, 389, DateTimeKind.Local).AddTicks(3472) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 19, 22, 5, 41, 916, DateTimeKind.Local).AddTicks(3233), new DateTime(2021, 11, 19, 22, 5, 41, 918, DateTimeKind.Local).AddTicks(8719) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 19, 22, 5, 41, 922, DateTimeKind.Local).AddTicks(3180), new DateTime(2021, 11, 19, 22, 5, 41, 922, DateTimeKind.Local).AddTicks(3212) });

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "FromDate", "ToDate", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 19, 22, 5, 41, 922, DateTimeKind.Local).AddTicks(8022), new DateTime(2021, 11, 19, 22, 5, 41, 922, DateTimeKind.Local).AddTicks(5000), new DateTime(2021, 11, 22, 22, 5, 41, 922, DateTimeKind.Local).AddTicks(5587), new DateTime(2021, 11, 19, 22, 5, 41, 922, DateTimeKind.Local).AddTicks(8654) });
        }
    }
}
