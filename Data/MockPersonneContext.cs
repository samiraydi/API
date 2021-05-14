using System.Collections.Generic;
using IIT.Clubs.Models;

namespace IIT.Clubs.Data
{
    public class MockPersonneContext : IPersonneRepo
    {
        public void CreatePersonne(Personne cmd)
        {
            throw new System.NotImplementedException();
        }

        public void DeletePersonne(Personne cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Personne> GetAllPersonne()
        {
            throw new System.NotImplementedException();
        }

        public Personne GetPersonneById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdatePersonne(Personne cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}