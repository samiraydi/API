using System;
using System.Collections.Generic;
using IIT.Clubs.Models;

namespace IIT.Clubs.Dtos
{
    public class EvennementReadDto
    {
        public int Id { get; set; }

        public string Titre { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }


        public int IdOrganisateur { get; set; }


        public Personne Organisateur { get; set; }
    }
}