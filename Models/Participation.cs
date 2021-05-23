/*using IIT.Clubs.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IIT.Clubs.API.Models
{
    [Table("Participation")]
    public class Participation
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("nombre_participant")]
        [Required]
        [MaxLength(20)]
        public int NbParticipant { get; set; }

        [Column("id_personne")]
        [Required]
        [MaxLength(20)]
        public int IdPersonne { get; set; }

        [Column("id_evennement")]
        [Required]
        [MaxLength(20)]
        public int IdEvennement { get; set; }

        public Evennement Evennement { get; set; }

        public Personne Personne { get; set; }
    }
}
*/