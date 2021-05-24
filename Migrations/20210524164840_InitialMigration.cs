using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IIT.Clubs.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "material",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_material", x => x.id);
                });

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
                name: "club",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    demaine_activite = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    date_creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    logo_club = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_fondateur = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_club", x => x.id);
                    table.ForeignKey(
                        name: "FK_club_Personne_id_fondateur",
                        column: x => x.id_fondateur,
                        principalTable: "Personne",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "evennement",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    id_organisateur = table.Column<int>(type: "int", nullable: false),
                    nombre_participants = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    ClubId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_evennement", x => x.id);
                    table.ForeignKey(
                        name: "FK_evennement_club_ClubId",
                        column: x => x.ClubId,
                        principalTable: "club",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_evennement_Personne_id_organisateur",
                        column: x => x.id_organisateur,
                        principalTable: "Personne",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inscription",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_membre = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    id_club = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    MembreId = table.Column<int>(type: "int", nullable: true),
                    ClubId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscription", x => x.id);
                    table.ForeignKey(
                        name: "FK_Inscription_club_ClubId",
                        column: x => x.ClubId,
                        principalTable: "club",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inscription_Personne_MembreId",
                        column: x => x.MembreId,
                        principalTable: "Personne",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Participation",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_participant = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    id_evennement = table.Column<int>(type: "int", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participation", x => x.id);
                    table.ForeignKey(
                        name: "FK_Participation_evennement_id_evennement",
                        column: x => x.id_evennement,
                        principalTable: "evennement",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participation_Personne_id_participant",
                        column: x => x.id_participant,
                        principalTable: "Personne",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reservation",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_evennement = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    id_salle = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    id_material = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    date_debut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    date_fin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    statut = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservation", x => x.id);
                    table.ForeignKey(
                        name: "FK_reservation_evennement_id_evennement",
                        column: x => x.id_evennement,
                        principalTable: "evennement",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reservation_material_id_material",
                        column: x => x.id_material,
                        principalTable: "material",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reservation_salle_id_salle",
                        column: x => x.id_salle,
                        principalTable: "salle",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_club_id_fondateur",
                table: "club",
                column: "id_fondateur");

            migrationBuilder.CreateIndex(
                name: "IX_evennement_ClubId",
                table: "evennement",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_evennement_id_organisateur",
                table: "evennement",
                column: "id_organisateur");

            migrationBuilder.CreateIndex(
                name: "IX_Inscription_ClubId",
                table: "Inscription",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscription_MembreId",
                table: "Inscription",
                column: "MembreId");

            migrationBuilder.CreateIndex(
                name: "IX_Participation_id_evennement",
                table: "Participation",
                column: "id_evennement");

            migrationBuilder.CreateIndex(
                name: "IX_Participation_id_participant",
                table: "Participation",
                column: "id_participant");

            migrationBuilder.CreateIndex(
                name: "IX_reservation_id_evennement",
                table: "reservation",
                column: "id_evennement");

            migrationBuilder.CreateIndex(
                name: "IX_reservation_id_material",
                table: "reservation",
                column: "id_material");

            migrationBuilder.CreateIndex(
                name: "IX_reservation_id_salle",
                table: "reservation",
                column: "id_salle");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inscription");

            migrationBuilder.DropTable(
                name: "Participation");

            migrationBuilder.DropTable(
                name: "reservation");

            migrationBuilder.DropTable(
                name: "evennement");

            migrationBuilder.DropTable(
                name: "material");

            migrationBuilder.DropTable(
                name: "salle");

            migrationBuilder.DropTable(
                name: "club");

            migrationBuilder.DropTable(
                name: "Personne");
        }
    }
}
