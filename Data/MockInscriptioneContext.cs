using System.Collections.Generic;
using IIT.Clubs.Models;

namespace IIT.Clubs.Data
{
    public class MockInscriptionContext : IInscriptioneRepo
    {
        public void CreateInscription(Inscription cmd)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteInscription(Inscription cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Inscription> GetAllInscriptions()
        {
            throw new System.NotImplementedException();
        }

        public Inscription GetInscriptionById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateInscription(Inscription cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}