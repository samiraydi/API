using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IIT.Clubs.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personne",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom_personne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prenom_personne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_naissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    organisation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personne", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "salle",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    emplacement = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salle", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "evennement",
                columns: table => new
                {
                    organisateur_id = table.Column<int>(type: "int", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_evennement", x => x.organisateur_id);
                    table.ForeignKey(
                        name: "FK_evennement_Personne_organisateur_id",
                        column: x => x.organisateur_id,
                        principalTable: "Personne",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reservation",
                columns: table => new
                {
                    id_evennement = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    id_salle = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date_debut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    date_fin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    statut = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservation", x => new { x.id_salle, x.id_evennement });
                    table.ForeignKey(
                        name: "FK_reservation_evennement_id_evennement",
                        column: x => x.id_evennement,
                        principalTable: "evennement",
                        principalColumn: "organisateur_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reservation_salle_id_salle",
                        column: x => x.id_salle,
                        principalTable: "salle",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_reservation_id_evennement",
                table: "reservation",
                column: "id_evennement");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reservation");

            migrationBuilder.DropTable(
                name: "evennement");

            migrationBuilder.DropTable(
                name: "salle");

            migrationBuilder.DropTable(
                name: "Personne");
        }
    }
}
