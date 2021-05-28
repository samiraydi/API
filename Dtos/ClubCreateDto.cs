using IIT.Clubs.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace IIT.Clubs.Dtos
{
    public class ClubCreateDto
    {
        public string Nom { get; set; }

        public string Description { get; set; }

        public string DemaineActivite { get; set; }

        public DateTime Date { get; set; }

        public string Logo { get; set; }

        public int IdFondateur { get; set; }
    }
}