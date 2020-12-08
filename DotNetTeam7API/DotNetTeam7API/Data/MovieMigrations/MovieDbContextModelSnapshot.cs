﻿// <auto-generated />
using DotNetTeam7API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DotNetTeam7API.Data.MovieMigrations
{
    [DbContext(typeof(MovieDbContext))]
    partial class MovieDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DotNetTeam7API.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 18,
                            Name = "Drama"
                        },
                        new
                        {
                            Id = 10765,
                            Name = "Annimation"
                        });
                });

            modelBuilder.Entity("DotNetTeam7API.Models.Movie", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("backdrop_path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("first_air_date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("original_language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("original_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("overview")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("popularity")
                        .HasColumnType("float");

                    b.Property<string>("poster_path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("vote_average")
                        .HasColumnType("float");

                    b.Property<int>("vote_count")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            id = 89641,
                            backdrop_path = "/mXouvrZbn8YpZMURGvw30QK8qfo.jpg",
                            first_air_date = "2019-08-22",
                            name = "Love Alarm",
                            original_language = "ko",
                            original_name = "좋아하면 울리는",
                            overview = "Love Alarm is an app that tells you if someone within a 10-meter radius has a crush on you. It quickly becomes a social phenomenon. While everyone talks about it and uses it to test their love and popularity, Jojo is one of the few people who have yet to download the app. However, she soon faces a love triangle situation between Sun-oh whom she starts to have feelings for, and Hye-young, who has had a huge crush on her.",
                            popularity = 166.60499999999999,
                            poster_path = "/s87JyAWtRLLlmsYWXTED1l8henB.jpg",
                            vote_average = 8.4000000000000004,
                            vote_count = 577
                        });
                });

            modelBuilder.Entity("DotNetTeam7API.Models.MovieGenre", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("MovieGenres");

                    b.HasData(
                        new
                        {
                            MovieId = 89641,
                            GenreId = 18
                        },
                        new
                        {
                            MovieId = 89641,
                            GenreId = 10765
                        });
                });

            modelBuilder.Entity("DotNetTeam7API.Models.MovieGenre", b =>
                {
                    b.HasOne("DotNetTeam7API.Models.Genre", "Genre")
                        .WithMany("MovieGenre")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DotNetTeam7API.Models.Movie", "Movie")
                        .WithMany("MovieGenre")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
