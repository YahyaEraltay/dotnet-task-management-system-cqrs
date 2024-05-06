using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagementSystem.Infrastructure.Migrations
{
    public partial class RestrictDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoTasks_Users_AssignedUserId",
                table: "ToDoTasks");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoTasks_Users_AssignedUserId",
                table: "ToDoTasks",
                column: "AssignedUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoTasks_Users_AssignedUserId",
                table: "ToDoTasks");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoTasks_Users_AssignedUserId",
                table: "ToDoTasks",
                column: "AssignedUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
