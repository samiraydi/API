using System;
using IIT.Clubs.Domain;

namespace IIT.Clubs.Dtos.Response
{
    // We are inheriting from AuthResult class
    public class RegistrationResponse : AuthResult
    {
        public string Status { get; set; }
        public string Message { get; set; }

    }
}
