using Microsoft.EntityFrameworkCore.Migrations;

namespace MyGoalPlanner.Api.Migrations
{
    public partial class UpdatingNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActionId",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActionId",
                table: "Notes");
        }
    }
}
