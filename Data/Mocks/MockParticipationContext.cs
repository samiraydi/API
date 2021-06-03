using System.Collections.Generic;
using IIT.Clubs.Models;

namespace IIT.Clubs.Data
{
    public class MockParticipationContext : IParticipationeRepo
    {
        public void CreateParticipation(Participation cmd)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteParticipation(Participation cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Participation> GetAllParticipations()
        {
            throw new System.NotImplementedException();
        }

        public Participation GetParticipationById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateParticipation(Participation cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}