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
        public DbSet<Personne> Personne { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
                .HasKey(c => new { c.IdSalle, c.IdEvennement });
            modelBuilder.Entity<Reservation>()
                .HasOne(e => e.Evennement)
                .WithMany(e => e.Reservations)
                .HasForeignKey(e => e.IdEvennement);

            modelBuilder.Entity<Reservation>()
                .HasOne(e => e.Salle)
                .WithMany(e => e.Reservations)
                .HasForeignKey(e => e.IdSalle);

            ///////
            ///

            modelBuilder.Entity<Evennement>()
                .HasKey(c => new { c.IdPersonne});
            modelBuilder.Entity<Evennement>()
                .HasOne(e => e.Personne)
                .WithMany(e => e.Evennement)
                .HasForeignKey(e => e.IdPersonne);
        }
    }
}