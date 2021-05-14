using System.ComponentModel.DataAnnotations;

namespace IIT.Clubs.Dtos
{
    public class SalleCreateDto
    {
        [Required]
        [MaxLength(250)]
        public string nom { get; set; }

        [Required]
        public string emplacement { get; set; }

    }
}