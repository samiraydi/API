using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace IIT.Clubs.Models
{
    [Table("Inscription")]
    public class Inscription

    {
        //
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("login")]
        public string NomMembre { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("id_membre")]
        [MaxLength(20)]
        public int IdMembre { get; set; }

        [Column("id_club")]
        [MaxLength(20)]
        public int IdClub { get; set; }

        public Personne Membre { get; set; }

        public Club Club { get; set; }


    }
}