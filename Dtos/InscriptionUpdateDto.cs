using System.ComponentModel.DataAnnotations;

namespace IIT.Clubs.Dtos
{
    public class InscriptionUpdateDto
    {

        public string Login { get; set; }

        public string PasswordHash { get; set; }

    }
}