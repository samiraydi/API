using System;
using System.ComponentModel.DataAnnotations;

namespace IIT.Clubs.Dtos
{
    public class EvennementUpdateDto
    {
        [Required]
        [MaxLength(250)]
        public string Titre { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int Organisateur { get; set; }

    }
}