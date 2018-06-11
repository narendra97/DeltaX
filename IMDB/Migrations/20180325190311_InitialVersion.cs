using imdb.Domain;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace imdb.Migrations
{
    public partial class InitialVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Created_At = table.Column<DateTime>(nullable: false),
                    DOB = table.Column<DateTime>(nullable: false),
                    Sex = table.Column<string>(nullable: false),
                    Bio = table.Column<string>(maxLength: 255, nullable: false),
                    Updated_At = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
               name: "Producers",
               columns: table => new
               {
                   Id = table.Column<int>(nullable: false)
                       .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                   Name = table.Column<string>(nullable: false),
                   Created_At = table.Column<DateTime>(nullable: false),
                   DOB = table.Column<DateTime>(nullable: false),
                   Sex = table.Column<string>(nullable: false),
                   BIO = table.Column<string>(nullable: false),
                   Updated_At = table.Column<DateTime>(nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Producers", x => x.Id);
               });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProducerId = table.Column<int>(nullable: true),
                    ActorId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Created_At = table.Column<DateTime>(nullable: false),
                    YearOfReleased = table.Column<DateTime>(nullable: false),
                    Plot = table.Column<string>(maxLength: 255, nullable: false),
                    Updated_At = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Producers_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Producers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Movies_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            

            migrationBuilder.CreateTable(
                name: "Actor_Movie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                       .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ActorId = table.Column<int>(nullable: true),
                    MovieId = table.Column<int>(nullable: true),
                    Created_At = table.Column<DateTime>(nullable: false),
                    Updated_At = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actor_Movie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actor_Movie_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Actor_Movie_Movies_MovieId",
                        column: y => y.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
               name: "Producer_Movie",
               columns: table => new
               {
                   Id = table.Column<int>(nullable: false)
                       .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                   ProducerId = table.Column<int>(nullable: true),
                   MovieId = table.Column<int>(nullable: true),
                   Created_At = table.Column<DateTime>(nullable: false),
                   Updated_At = table.Column<DateTime>(nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Producer_Movie", x => x.Id);
                   table.ForeignKey(
                       name: "FK_Producer_Movie_Producers_ProducerId",
                       column: x => x.ProducerId,
                       principalTable: "Producers",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.SetNull);
                   table.ForeignKey(
                       name: "FK_Producer_Movie_Movies_MovieId",
                       column: y => y.MovieId,
                       principalTable: "Movies",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.SetNull);
               });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_ProducerId",
                table: "Movies",
                column: "ProducerId");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
               name: "Producers");
        }
    }
}
