using Microsoft.EntityFrameworkCore.Migrations;

namespace HikingTrail.Migrations
{
    public partial class AddSeasons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartingElevation",
                table: "Trails");

            migrationBuilder.AddColumn<string>(
                name: "Season",
                table: "Trails",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Season",
                table: "Trails");

            migrationBuilder.AddColumn<int>(
                name: "StartingElevation",
                table: "Trails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
