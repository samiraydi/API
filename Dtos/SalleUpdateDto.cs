using System.ComponentModel.DataAnnotations;

namespace IIT.Clubs.Dtos
{
    public class SalleUpdateDto
    {
        [Required]
        [MaxLength(250)]
        public string Nom { get; set; }

        [Required]
        public string Emplacement { get; set; }

    }
}