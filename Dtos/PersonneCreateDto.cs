using System;
using System.ComponentModel.DataAnnotations;

namespace IIT.Clubs.Dtos
{
    public class PersonneCreateDto
    {
        [Required]
        [MaxLength(250)]
        public string Nom { get; set; }

        [Required]
        public string Prenom { get; set; }

        [Required]
        public DateTime DateNaissance { get; set; }

        [Required]
        public string Occupation { get; set; }

        [Required]
        public string Organisateur { get; set; }
    }
}