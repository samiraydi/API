using System.ComponentModel.DataAnnotations;

namespace IIT.Clubs.Dtos
{
    public class InscriptionUpdateDto
    {
        [Required]
        [MaxLength(250)]
        public string NomMembre { get; set; }

        [Required]
        public string Password { get; set; }

    }
}