using System;
using System.ComponentModel.DataAnnotations;

namespace IIT.Clubs.Dtos
{
    public class PersonneUpdateDto
    {
        [Required]
        [MaxLength(250)]
        public string Nom { get; set; }

        [Required]
        public string Prenom { get; set; }

        [Required]
        public DateTime DateNaissance { get; set; }

        [Required]
        public int Occupation { get; set; }

        [Required]
        public string Organisation { get; set; }
    }
}