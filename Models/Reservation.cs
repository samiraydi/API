using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IIT.Clubs.Models
{
    [Table("reservation")]
    public class Reservation
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("id_evennement")]
        [Required]
        [MaxLength(20)]
        public int IdEvennement{ get; set; }

        [Column("id_salle")]
        [Required]
        [MaxLength(20)]
        public int IdSalle { get; set; }

        [Column("date_debut")]
        [Required]
        public DateTime DateDebut { get; set; }

        [Column("date_fin")]
        [Required]
        public DateTime DateFin { get; set; }

        [Column("statut")]
        [Required]
        [MaxLength(20)]
        public string Statut { get; set; }

        public Evennement Evennement { get; set; }

        public Salle Salle { get; set; }

    }
}