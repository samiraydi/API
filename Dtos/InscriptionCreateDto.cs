using System.ComponentModel.DataAnnotations;

namespace IIT.Clubs.Dtos
{
    public class InscriptionCreateDto
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int IdMembre { get; set; }

        public int IdClub { get; set; }
    }
}