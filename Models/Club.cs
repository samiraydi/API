using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using System;

namespace IIT.Clubs.Models
{
    [Table("club")]
    public class Club

    {
        public Club()
        {
            Inscriptions = new HashSet<Inscription>();

            Evennements = new HashSet<Evennement>();
        }
        //
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("nom")]
        [Required]
        [MaxLength(250)]
        public string Nom { get; set; }

        [Column("description")]
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }
        
        [Column("demaine_activite")]
        [Required]
        [MaxLength(250)]
        public string DemaineActivite { get; set; }

        [Required]
        [Column("date_creation")]
        public DateTime Date { get; set; }

        [Required]
        [Column("logo_club")]
        public string Logo { get; set; }

        [Column("id_fondateur")]
        public int IdFondateur { get; set; }

        public Personne Fondateur { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<Inscription> Inscriptions { get; set; }

        public ICollection<Evennement> Evennements { get; set; }

    }
}