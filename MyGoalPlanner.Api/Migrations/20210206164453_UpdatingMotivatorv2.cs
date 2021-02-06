using Microsoft.EntityFrameworkCore.Migrations;

namespace MyGoalPlanner.Api.Migrations
{
    public partial class UpdatingMotivatorv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prize",
                table: "Motivators");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Prize",
                table: "Motivators",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
