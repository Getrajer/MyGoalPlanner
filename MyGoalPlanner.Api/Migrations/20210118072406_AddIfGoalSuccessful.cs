using Microsoft.EntityFrameworkCore.Migrations;

namespace MyGoalPlanner.Api.Migrations
{
    public partial class AddIfGoalSuccessful : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Succesfully",
                table: "Goals",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Succesfully",
                table: "Goals");
        }
    }
}
