using System;
using System.ComponentModel.DataAnnotations;
using IIT.Clubs.Models;

namespace IIT.Clubs.Dtos
{
    public class ParticipationReadDto
    {
        public int Id { get; set; }

        public int IdParticipant { get; set; }

        public int IdEvennement { get; set; }

        public Evennement Evennement { get; set; }

        public Personne Participant { get; set; }
    }
}