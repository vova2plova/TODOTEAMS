using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Backend.Migrations
{
    public partial class AddTaskModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isPrivate",
                table: "Plan",
                newName: "IsPrivate");

            migrationBuilder.RenameColumn(
                name: "Complited",
                table: "Plan",
                newName: "IsComplited");

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdPlan = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IsComplited = table.Column<bool>(type: "boolean", nullable: false),
                    TaskFK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Task_Plan_TaskFK",
                        column: x => x.TaskFK,
                        principalTable: "Plan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Task_TaskFK",
                table: "Task",
                column: "TaskFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.RenameColumn(
                name: "IsPrivate",
                table: "Plan",
                newName: "isPrivate");

            migrationBuilder.RenameColumn(
                name: "IsComplited",
                table: "Plan",
                newName: "Complited");
        }
    }
}
