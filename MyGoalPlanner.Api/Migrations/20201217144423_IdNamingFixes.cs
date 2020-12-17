using Microsoft.EntityFrameworkCore.Migrations;

namespace MyGoalPlanner.Api.Migrations
{
    public partial class IdNamingFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TypeOfGoals",
                newName: "TypeOfGoalId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Steps",
                newName: "StepId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Notes",
                newName: "NoteId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Motivators",
                newName: "MotivatorId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Goals",
                newName: "GoalId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "GoalItems",
                newName: "GoalItemId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "GoalContitions",
                newName: "GoalConditionId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "FontAwesomeIcons",
                newName: "FontAwesomeIconId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Files",
                newName: "FileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeOfGoalId",
                table: "TypeOfGoals",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "StepId",
                table: "Steps",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "NoteId",
                table: "Notes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MotivatorId",
                table: "Motivators",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "GoalId",
                table: "Goals",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "GoalItemId",
                table: "GoalItems",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "GoalConditionId",
                table: "GoalContitions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "FontAwesomeIconId",
                table: "FontAwesomeIcons",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "FileId",
                table: "Files",
                newName: "Id");
        }
    }
}
