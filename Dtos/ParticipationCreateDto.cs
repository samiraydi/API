using System;
using System.ComponentModel.DataAnnotations;
using IIT.Clubs.Models;

namespace IIT.Clubs.Dtos
{
    public class ParticipationCreateDto
    {
        public int IdParticipant { get; set; }

        public int IdEvennement { get; set; }

    }
}