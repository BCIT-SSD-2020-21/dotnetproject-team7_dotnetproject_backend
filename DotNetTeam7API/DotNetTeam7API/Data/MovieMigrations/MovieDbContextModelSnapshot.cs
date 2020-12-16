﻿// <auto-generated />
using System;
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
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("DotNetTeam7API.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Backdrop_path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("First_air_date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Original_language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Original_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Overview")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Popularity")
                        .HasColumnType("float");

                    b.Property<string>("Poster_path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Vote_average")
                        .HasColumnType("float");

                    b.Property<int>("Vote_count")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Movies");
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
                });

            modelBuilder.Entity("DotNetTeam7API.Models.MovieUser", b =>
                {
                    b.Property<int>("MovieUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Fav")
                        .HasColumnType("bit");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Review")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MovieUserId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieUsers");
                });

            modelBuilder.Entity("DotNetTeam7API.Models.MovieGenre", b =>
                {
                    b.HasOne("DotNetTeam7API.Models.Genre", "Genre")
                        .WithMany("MovieGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DotNetTeam7API.Models.Movie", "Movie")
                        .WithMany("MovieGenres")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DotNetTeam7API.Models.MovieUser", b =>
                {
                    b.HasOne("DotNetTeam7API.Models.Movie", "Movie")
                        .WithMany("MovieUsers")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
