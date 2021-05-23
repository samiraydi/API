using System.ComponentModel.DataAnnotations;

namespace IIT.Clubs.Dtos
{
    public class MaterialCreateDto
    {
        [Required]
        [MaxLength(250)]
        public string Nom { get; set; }


    }
}