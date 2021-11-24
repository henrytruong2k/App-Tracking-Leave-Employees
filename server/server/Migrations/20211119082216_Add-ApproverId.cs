using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class AddApproverId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ApproverId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<string>(
                name: "ApproverId",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
