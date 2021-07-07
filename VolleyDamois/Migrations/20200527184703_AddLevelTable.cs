using Microsoft.EntityFrameworkCore.Migrations;

namespace VolleyDamois.Migrations
{
    public partial class AddLevelTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "Confrontations");

            migrationBuilder.AddColumn<int>(
                name: "LevelId",
                table: "Confrontations",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Level",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Level", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Confrontations_LevelId",
                table: "Confrontations",
                column: "LevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Confrontations_Level_LevelId",
                table: "Confrontations",
                column: "LevelId",
                principalTable: "Level",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Confrontations_Level_LevelId",
                table: "Confrontations");

            migrationBuilder.DropTable(
                name: "Level");

            migrationBuilder.DropIndex(
                name: "IX_Confrontations_LevelId",
                table: "Confrontations");

            migrationBuilder.DropColumn(
                name: "LevelId",
                table: "Confrontations");

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Confrontations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
