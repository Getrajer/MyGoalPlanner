using Microsoft.EntityFrameworkCore.Migrations;

namespace MyGoalPlanner.Api.Migrations
{
    public partial class StepCompletionadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "StepCompleted",
                table: "Steps",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StepCompleted",
                table: "Steps");
        }
    }
}
