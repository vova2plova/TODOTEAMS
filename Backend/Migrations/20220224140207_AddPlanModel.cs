using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Backend.Migrations
{
    public partial class AddPlanModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdUser = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    isPrivate = table.Column<bool>(type: "boolean", nullable: false),
                    Complited = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanUser",
                columns: table => new
                {
                    PersonalPlansId = table.Column<int>(type: "integer", nullable: false),
                    PlansFK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanUser", x => new { x.PersonalPlansId, x.PlansFK });
                    table.ForeignKey(
                        name: "FK_PlanUser_Plan_PersonalPlansId",
                        column: x => x.PersonalPlansId,
                        principalTable: "Plan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanUser_User_PlansFK",
                        column: x => x.PlansFK,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanUser_PlansFK",
                table: "PlanUser",
                column: "PlansFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanUser");

            migrationBuilder.DropTable(
                name: "Plan");
        }
    }
}
