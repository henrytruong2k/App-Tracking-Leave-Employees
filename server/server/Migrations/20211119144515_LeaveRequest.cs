using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class LeaveRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateById = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    RequestById = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_Employees_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_Employees_RequestById",
                        column: x => x.RequestById,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_CreatedById",
                table: "LeaveRequests",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_RequestById",
                table: "LeaveRequests",
                column: "RequestById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequests");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "ApproverId", "CreatedAt", "DateOfBirth", "Dayoff", "Email", "FullName", "Password", "Role", "UpdatedAt" },
                values: new object[] { 1, null, 1, new DateTime(2021, 11, 19, 16, 15, 4, 895, DateTimeKind.Local).AddTicks(5431), null, 5, "hr@gmail.com", "Nguyen Van HR", "1234", "HR", new DateTime(2021, 11, 19, 16, 15, 4, 896, DateTimeKind.Local).AddTicks(9188) });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "ApproverId", "CreatedAt", "DateOfBirth", "Dayoff", "Email", "FullName", "Password", "Role", "UpdatedAt" },
                values: new object[] { 2, null, 1, new DateTime(2021, 11, 19, 16, 15, 4, 898, DateTimeKind.Local).AddTicks(5806), null, 5, "emp@gmail.com", "Nguyen Van Emp", "1234", "Employee", new DateTime(2021, 11, 19, 16, 15, 4, 898, DateTimeKind.Local).AddTicks(5833) });
        }
    }
}
