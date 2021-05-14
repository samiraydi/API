using System.ComponentModel.DataAnnotations;

namespace IIT.Clubs.Dtos
{
    public class SalleReadDto
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public string Emplacement { get; set; }
    }
}