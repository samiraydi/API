using System;
using System.ComponentModel.DataAnnotations;

namespace IIT.Clubs.Dtos.Request
{
    public class UserLoginRequestDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
