using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace IIT.Clubs.Models
{
    [Table("salle")]
    public class Salle

    {
        public Salle()
        {
            Reservations = new HashSet<Reservation>();
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

        [Column("emplacement")]
        [Required]
        [MaxLength(250)]
        public string Emplacement { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<Reservation> Reservations { get; set; }

    }
}