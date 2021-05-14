using System;
using System.Collections.Generic;
using IIT.Clubs.Models;

namespace IIT.Clubs.Dtos
{
    public class PersonneReadDto
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public DateTime DateNaissance { get; set; }

        public int Occupation { get; set; }

        public string Organisation { get; set; }

        //public ICollection<Reservation> Reservations { get; set; } 
    }
}