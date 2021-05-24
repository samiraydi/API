using IIT.Clubs.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IIT.Clubs.Models
{
    [Table("Participation")]
    public class Participation
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("id_participant")]
        [MaxLength(20)]
        public int IdParticipant { get; set; }

        [Column("id_evennement")]
        [MaxLength(20)]
        public int IdEvennement { get; set; }

        public Evennement Evennement { get; set; }

        public Personne Participant { get; set; }
    }
}