using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetTeam7API.Data.MovieMigrations
{
    public partial class InitialMovieDbSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    backdrop_path = table.Column<string>(nullable: true),
                    first_air_date = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    original_language = table.Column<string>(nullable: true),
                    original_name = table.Column<string>(nullable: true),
                    overview = table.Column<string>(nullable: true),
                    popularity = table.Column<double>(nullable: false),
                    poster_path = table.Column<string>(nullable: true),
                    vote_average = table.Column<double>(nullable: false),
                    vote_count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MovieGenres",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenres", x => new { x.MovieId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_MovieGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieGenres_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[] { 18, "Drama" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[] { 10765, "Annimation" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "id", "backdrop_path", "first_air_date", "name", "original_language", "original_name", "overview", "popularity", "poster_path", "vote_average", "vote_count" },
                values: new object[] { 89641, "/mXouvrZbn8YpZMURGvw30QK8qfo.jpg", "2019-08-22", "Love Alarm", "ko", "좋아하면 울리는", "Love Alarm is an app that tells you if someone within a 10-meter radius has a crush on you. It quickly becomes a social phenomenon. While everyone talks about it and uses it to test their love and popularity, Jojo is one of the few people who have yet to download the app. However, she soon faces a love triangle situation between Sun-oh whom she starts to have feelings for, and Hye-young, who has had a huge crush on her.", 166.60499999999999, "/s87JyAWtRLLlmsYWXTED1l8henB.jpg", 8.4000000000000004, 577 });

            migrationBuilder.InsertData(
                table: "MovieGenres",
                columns: new[] { "MovieId", "GenreId" },
                values: new object[] { 89641, 18 });

            migrationBuilder.InsertData(
                table: "MovieGenres",
                columns: new[] { "MovieId", "GenreId" },
                values: new object[] { 89641, 10765 });

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenres_GenreId",
                table: "MovieGenres",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieGenres");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
