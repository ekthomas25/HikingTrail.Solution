using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HikingTrail.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trails",
                columns: table => new
                {
                    TrailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Length = table.Column<double>(type: "double", nullable: false),
                    Configuration = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    StartingElevation = table.Column<int>(type: "int", nullable: false),
                    ElevationGain = table.Column<int>(type: "int", nullable: false),
                    Difficulty = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    FamilyFriendly = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    DistanceFromPdx = table.Column<double>(type: "double", nullable: false),
                    Latitude = table.Column<double>(type: "double", nullable: false),
                    Longitude = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trails", x => x.TrailId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trails");
        }
    }
}
