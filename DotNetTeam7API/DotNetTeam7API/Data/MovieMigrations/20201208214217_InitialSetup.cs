using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetTeam7API.Data.MovieMigrations
{
    public partial class InitialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenre_Genre_GenreId",
                table: "MovieGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenre_Movies_MovieId",
                table: "MovieGenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieGenre",
                table: "MovieGenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genre",
                table: "Genre");

            migrationBuilder.RenameTable(
                name: "MovieGenre",
                newName: "MovieGenres");

            migrationBuilder.RenameTable(
                name: "Genre",
                newName: "Genres");

            migrationBuilder.RenameColumn(
                name: "vote_count",
                table: "Movies",
                newName: "Vote_count");

            migrationBuilder.RenameColumn(
                name: "vote_average",
                table: "Movies",
                newName: "Vote_average");

            migrationBuilder.RenameColumn(
                name: "poster_path",
                table: "Movies",
                newName: "Poster_path");

            migrationBuilder.RenameColumn(
                name: "popularity",
                table: "Movies",
                newName: "Popularity");

            migrationBuilder.RenameColumn(
                name: "overview",
                table: "Movies",
                newName: "Overview");

            migrationBuilder.RenameColumn(
                name: "original_name",
                table: "Movies",
                newName: "Original_name");

            migrationBuilder.RenameColumn(
                name: "original_language",
                table: "Movies",
                newName: "Original_language");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Movies",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "first_air_date",
                table: "Movies",
                newName: "First_air_date");

            migrationBuilder.RenameColumn(
                name: "backdrop_path",
                table: "Movies",
                newName: "Backdrop_path");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Movies",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_MovieGenre_GenreId",
                table: "MovieGenres",
                newName: "IX_MovieGenres_GenreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieGenres",
                table: "MovieGenres",
                columns: new[] { "MovieId", "GenreId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenres_Genres_GenreId",
                table: "MovieGenres",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenres_Movies_MovieId",
                table: "MovieGenres",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenres_Genres_GenreId",
                table: "MovieGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenres_Movies_MovieId",
                table: "MovieGenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieGenres",
                table: "MovieGenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.RenameTable(
                name: "MovieGenres",
                newName: "MovieGenre");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "Genre");

            migrationBuilder.RenameColumn(
                name: "Vote_count",
                table: "Movies",
                newName: "vote_count");

            migrationBuilder.RenameColumn(
                name: "Vote_average",
                table: "Movies",
                newName: "vote_average");

            migrationBuilder.RenameColumn(
                name: "Poster_path",
                table: "Movies",
                newName: "poster_path");

            migrationBuilder.RenameColumn(
                name: "Popularity",
                table: "Movies",
                newName: "popularity");

            migrationBuilder.RenameColumn(
                name: "Overview",
                table: "Movies",
                newName: "overview");

            migrationBuilder.RenameColumn(
                name: "Original_name",
                table: "Movies",
                newName: "original_name");

            migrationBuilder.RenameColumn(
                name: "Original_language",
                table: "Movies",
                newName: "original_language");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Movies",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "First_air_date",
                table: "Movies",
                newName: "first_air_date");

            migrationBuilder.RenameColumn(
                name: "Backdrop_path",
                table: "Movies",
                newName: "backdrop_path");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Movies",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_MovieGenres_GenreId",
                table: "MovieGenre",
                newName: "IX_MovieGenre_GenreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieGenre",
                table: "MovieGenre",
                columns: new[] { "MovieId", "GenreId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genre",
                table: "Genre",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenre_Genre_GenreId",
                table: "MovieGenre",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenre_Movies_MovieId",
                table: "MovieGenre",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
