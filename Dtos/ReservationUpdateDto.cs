using System;
using System.ComponentModel.DataAnnotations;
using IIT.Clubs.Models;

namespace IIT.Clubs.Dtos
{
    public class ReservationUpdateDto
    {
        [Required]
        [MaxLength(250)]
        public int IdEvennement{ get; set; }

        [Required]
        public int IdSalle { get; set; }

        [Required]
        public DateTime DateDebut { get; set; }

        [Required]
        public DateTime DateFin { get; set; }

        [Required]
        public string Statut { get; set; }

        [Required]
        public Evennement Evennement { get; set; }

        [Required]
        public Salle Salle { get; set; }

    }
}