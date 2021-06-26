using IIT.Clubs.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace IIT.Clubs.Dtos
{
    public class EvennementUpdateDto
    {

        public string Titre { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }
        public int NbParticipants { get; set; }

        public int IdOrganisateur { get; set; }
        public int IdClub { get; set; }

    }
}