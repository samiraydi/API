using System.Collections.Generic;
using IIT.Clubs.Models;

namespace IIT.Clubs.Data
{
    public class MockEvennementeContext : IEvennementeRepo
    {
        public void CreateEvennement(Evennement cmd)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteEvennement(Evennement cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Evennement> GetAllEvennements()
        {
            throw new System.NotImplementedException();
        }

        public Evennement GetEvennementById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateEvennement(Evennement cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}