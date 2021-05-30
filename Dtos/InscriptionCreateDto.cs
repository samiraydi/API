using System.ComponentModel.DataAnnotations;

namespace IIT.Clubs.Dtos
{
    public class InscriptionCreateDto
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public int IdMembre { get; set; }

        public int IdClub { get; set; }
    }
}