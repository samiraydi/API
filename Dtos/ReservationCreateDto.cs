using System;
using System.ComponentModel.DataAnnotations;
using IIT.Clubs.Models;

namespace IIT.Clubs.Dtos
{
    public class ReservationCreateDto
    {

        public DateTime DateDebut { get; set; }
 
        public DateTime DateFin { get; set; }

        public int IdEvennement { get; set; }

        public int IdSalle { get; set; }

    }
}