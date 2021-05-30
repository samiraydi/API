using System;
using IIT.Clubs.Models;

namespace IIT.Clubs.Dtos
{
    public class AuthentificateRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
