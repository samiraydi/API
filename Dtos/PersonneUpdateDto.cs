using System;
using System.ComponentModel.DataAnnotations;

namespace IIT.Clubs.Dtos
{
    public class PersonneUpdateDto
    {
        public string Nom { get; set; }

        public string Prenom { get; set; }

        public DateTime DateNaissance { get; set; }

        public string Occupation { get; set; }

        public string Organisation { get; set; }
    }
}