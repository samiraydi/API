﻿// <auto-generated />
using System;
using IIT.Clubs.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IIT.Clubs.API.Migrations
{
    [DbContext(typeof(IITContext))]
    partial class IITContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IIT.Clubs.Models.Evennement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("description");

                    b.Property<int>("IdOrganisateur")
                        .HasColumnType("int")
                        .HasColumnName("organisateur_id");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("titre");

                    b.HasKey("Id");

                    b.HasIndex("IdOrganisateur");

                    b.ToTable("evennement");
                });

            modelBuilder.Entity("IIT.Clubs.Models.Personne", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_naissance");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nom_personne");

                    b.Property<string>("Occupation")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("occupation");

                    b.Property<string>("Organisation")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("organisation");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("prenom_personne");

                    b.HasKey("Id");

                    b.ToTable("Personne");
                });

            modelBuilder.Entity("IIT.Clubs.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateDebut")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_debut");

                    b.Property<DateTime>("DateFin")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_fin");

                    b.Property<int>("IdEvennement")
                        .HasMaxLength(20)
                        .HasColumnType("int")
                        .HasColumnName("id_evennement");

                    b.Property<int>("IdSalle")
                        .HasMaxLength(20)
                        .HasColumnType("int")
                        .HasColumnName("id_salle");

                    b.Property<string>("Statut")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("statut");

                    b.HasKey("Id");

                    b.HasIndex("IdEvennement");

                    b.HasIndex("IdSalle");

                    b.ToTable("reservation");
                });

            modelBuilder.Entity("IIT.Clubs.Models.Salle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Emplacement")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("emplacement");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("nom");

                    b.HasKey("Id");

                    b.ToTable("salle");
                });

            modelBuilder.Entity("IIT.Clubs.Models.Evennement", b =>
                {
                    b.HasOne("IIT.Clubs.Models.Personne", "Organisateur")
                        .WithMany("Evennements")
                        .HasForeignKey("IdOrganisateur")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organisateur");
                });

            modelBuilder.Entity("IIT.Clubs.Models.Reservation", b =>
                {
                    b.HasOne("IIT.Clubs.Models.Evennement", "Evennement")
                        .WithMany("Reservations")
                        .HasForeignKey("IdEvennement")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IIT.Clubs.Models.Salle", "Salle")
                        .WithMany("Reservations")
                        .HasForeignKey("IdSalle")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evennement");

                    b.Navigation("Salle");
                });

            modelBuilder.Entity("IIT.Clubs.Models.Evennement", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("IIT.Clubs.Models.Personne", b =>
                {
                    b.Navigation("Evennements");
                });

            modelBuilder.Entity("IIT.Clubs.Models.Salle", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
