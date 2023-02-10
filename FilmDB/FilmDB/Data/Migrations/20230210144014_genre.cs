using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmDB.Data.Migrations
{
    public partial class genre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenreID",
                table: "Films",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Films_GenreID",
                table: "Films",
                column: "GenreID");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Genres_GenreID",
                table: "Films",
                column: "GenreID",
                principalTable: "Genres",
                principalColumn: "GenreID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Genres_GenreID",
                table: "Films");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Films_GenreID",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "GenreID",
                table: "Films");
        }
    }
}
