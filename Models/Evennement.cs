using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace IIT.Clubs.Models
{
    [Table("evennement")]
    public class Evennement
    {
        public Evennement()
        {
            Reservations = new HashSet<Reservation>();
           // Participations = new HashSet<Participation>();
        }

        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        [Column("titre")]
        public string Titre { get; set; }

        [Required]
        [MaxLength(250)]
        [Column("description")]
        public string Description { get; set; }

        [Required]
        [Column("date")]
        public DateTime Date { get; set; }

        [Column("organisateur_id")]
        public int IdOrganisateur { get; set; }


        public Personne Organisateur { get; set; }

        //public IEnumerable<Personne> Participants { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<Reservation> Reservations { get; set; }
        /*
        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<Participation> Participations { get; set; }*/
    }
}
