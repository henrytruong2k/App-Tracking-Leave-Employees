using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class UpdateEmployee2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_ApproverId1",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ApproverId1",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ApproverId1",
                table: "Employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApproverId1",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ApproverId1",
                table: "Employees",
                column: "ApproverId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_ApproverId1",
                table: "Employees",
                column: "ApproverId1",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
