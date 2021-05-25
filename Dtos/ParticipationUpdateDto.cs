using System;
using System.ComponentModel.DataAnnotations;
using IIT.Clubs.Models;

namespace IIT.Clubs.Dtos
{
    public class ParticipationUpdateDto
    {
        public int IdParticipant { get; set; }

        public int IdEvennement { get; set; }

    }
}