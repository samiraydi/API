using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace IIT.Clubs.Models
{
    [Table("Personne")]
    public class Personne
    {

        public Personne()
        {
            Evennements = new HashSet<Evennement>();
            //  Participations = new HashSet<Participation>();
            Inscriptions = new HashSet<Inscription>();
        }

        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("nom_personne")]
        public string Nom { get; set; }

        [Column("prenom_personne")]
        public string Prenom { get; set; }

        [Column("date_naissance")]
        public DateTime DateNaissance { get; set; }

        [Column("occupation")]
        public string Occupation { get; set; }

        [Column("organisation")]
        public string Organisation { get; set; }


        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<Evennement> Evennements { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<Inscription> Inscriptions { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<Club> Clubs { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<Participation> Participations { get; set; }

        
    }
}
