using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KanbanTable.Migrations
{
    public partial class Task_nullable_relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KanbanTasks_KanbanProjects_ProjectID",
                table: "KanbanTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_KanbanTasks_TaskStatuses_StatusId",
                table: "KanbanTasks");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "KanbanTasks",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectID",
                table: "KanbanTasks",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_KanbanTasks_KanbanProjects_ProjectID",
                table: "KanbanTasks",
                column: "ProjectID",
                principalTable: "KanbanProjects",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_KanbanTasks_TaskStatuses_StatusId",
                table: "KanbanTasks",
                column: "StatusId",
                principalTable: "TaskStatuses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KanbanTasks_KanbanProjects_ProjectID",
                table: "KanbanTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_KanbanTasks_TaskStatuses_StatusId",
                table: "KanbanTasks");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "KanbanTasks",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectID",
                table: "KanbanTasks",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_KanbanTasks_KanbanProjects_ProjectID",
                table: "KanbanTasks",
                column: "ProjectID",
                principalTable: "KanbanProjects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KanbanTasks_TaskStatuses_StatusId",
                table: "KanbanTasks",
                column: "StatusId",
                principalTable: "TaskStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
