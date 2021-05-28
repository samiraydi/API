using System.ComponentModel.DataAnnotations;
using IIT.Clubs.Models;

namespace IIT.Clubs.Dtos
{
    public class InscriptionReadDto
    {
        public int Id { get; set; }

        public string NomMembre { get; set; }

        public string Password { get; set; }

        public int IdMembre { get; set; }

        public int IdClub { get; set; }

        public Personne Membre { get; set; }

        public Club Club { get; set; }
    }
}