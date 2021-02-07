using Microsoft.EntityFrameworkCore.Migrations;

namespace MyGoalPlanner.Api.Migrations
{
    public partial class FixingAction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ActivityTypeId",
                table: "Activities",
                newName: "ActivityConnectionId");

            migrationBuilder.AddColumn<string>(
                name: "ActivityConnection",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivityConnection",
                table: "Activities");

            migrationBuilder.RenameColumn(
                name: "ActivityConnectionId",
                table: "Activities",
                newName: "ActivityTypeId");
        }
    }
}
