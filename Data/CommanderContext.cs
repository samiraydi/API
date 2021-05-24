using IIT.Clubs.Models;
using Microsoft.EntityFrameworkCore;

namespace IIT.Clubs.Data
{
    public class IITContext : DbContext
    {
        public IITContext(DbContextOptions<IITContext> opt): base(opt)
        {
            
        }

        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Salle> Salles { get; set; }
        public DbSet<Evennement> Evennements { get; set; }
        public DbSet<Personne> Personnes { get; set; }
        public DbSet<Participation> Participations { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Inscription> Inscriptions { get; set; }
        public DbSet<Club> Clubs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Reservation>()
              //  .HasKey(c => new { c.IdSalle, c.IdEvennement });
            modelBuilder.Entity<Reservation>()
                .HasOne(e => e.Evennement)
                .WithMany(e => e.Reservations)
                .HasForeignKey(e => e.IdEvennement);

            modelBuilder.Entity<Reservation>()
                .HasOne(e => e.Salle)
                .WithMany(e => e.Reservations)
                .HasForeignKey(e => e.IdSalle);

            modelBuilder.Entity<Reservation>()
                .HasOne(e => e.Material)
                .WithMany(e => e.Reservations)
                .HasForeignKey(e => e.IdMaterial);


            //modelBuilder.Entity<Evennement>()
            //  .HasKey(c => new { c.IdOrganisateur});
            modelBuilder.Entity<Evennement>()
                .HasOne(e => e.Organisateur)
                .WithMany(e => e.Evennements)
                .HasForeignKey(e => e.IdOrganisateur);

            modelBuilder.Entity<Club>()
                .HasOne(e => e.Fondateur)
                .WithMany(e => e.Clubs)
                .HasForeignKey(e => e.IdFondateur);

            modelBuilder.Entity<Participation>()
                 .HasOne(e => e.Evennement)
                 .WithMany(e => e.Participations)
                 .HasForeignKey(e => e.IdEvennement);

             modelBuilder.Entity<Participation>()
                 .HasOne(e => e.Participant)
                 .WithMany(e => e.Participations)
                 .HasForeignKey(e => e.IdParticipant)
                 .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}