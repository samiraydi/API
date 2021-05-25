using System.ComponentModel.DataAnnotations;

namespace IIT.Clubs.Dtos
{
    public class InscriptionReadDto
    {
        public int Id { get; set; }

        public string NomMembre { get; set; }

        public string Password { get; set; }
    }
}