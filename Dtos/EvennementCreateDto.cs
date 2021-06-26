using IIT.Clubs.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace IIT.Clubs.Dtos
{
    public class EvennementCreateDto
    {
        [Required]
        public string Titre { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int NbParticipants { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int IdOrganisateur { get; set; }

        [Required]
        public int IdClub { get; set; }
    }
}