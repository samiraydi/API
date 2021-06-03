using System;
using System.ComponentModel.DataAnnotations;

namespace IIT.Clubs.Dtos.Request
{
    public class UserRegistrationRequestDto
    {
        [Required]
        public string Nom { get; set; }

        [Required]
        public string Prenom { get; set; }

        [Required]
        public DateTime DateNaissance { get; set; }

        [Required]
        public string Occupation { get; set; }

        [Required]
        public string Etablissement { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int IdClub { get; set; }
    }
}
