using System.Collections.Generic;
using IIT.Clubs.Models;

namespace IIT.Clubs.Data
{
    public class MockClubContext : IClubeRepo
    {
        public void CreateClub(Club cmd)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteClub(Club cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Club> GetAllClubs()
        {
            throw new System.NotImplementedException();
        }

        public Club GetClubById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateClub(Club cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}