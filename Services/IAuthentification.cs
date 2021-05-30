using System;
using IIT.Clubs.Dtos;

namespace IIT.Clubs.Services
{
    public interface IAuthentification
    {
        bool Authentifier(AuthentificateRequest request);
    }
}
