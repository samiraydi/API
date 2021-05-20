using System;
using System.ComponentModel.DataAnnotations;
using IIT.Clubs.Models;

namespace IIT.Clubs.Dtos
{
    public class ReservationUpdateDto
    {
        public int IdEvennement{ get; set; }


        public int IdSalle { get; set; }


        public DateTime DateDebut { get; set; }


        public DateTime DateFin { get; set; }


        public string Statut { get; set; }

     

    }
}