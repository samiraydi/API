﻿using IIT.Clubs.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace IIT.Clubs.Dtos
{
    public class EvennementUpdateDto
    {

        [Required]
        [MaxLength(250)]
        public string Titre { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public Personne Organisateur { get; set; }

        [Required]
        [MaxLength(250)]
        public int IdOrganisateur { get; set; }

    }
}