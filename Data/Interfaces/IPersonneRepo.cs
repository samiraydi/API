using System.Collections.Generic;
using IIT.Clubs.Models;

namespace IIT.Clubs.Data
{
    public interface IPersonneRepo
    {
        bool SaveChanges();


        IEnumerable<Personne> GetAllPersonne();

        Personne GetPersonneById(int id);

        void CreatePersonne(Personne cmd);

        void UpdatePersonne(Personne cmd);

        void DeletePersonne(Personne cmd);
    }
}