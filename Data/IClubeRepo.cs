using System.Collections.Generic;
using IIT.Clubs.Models;

namespace IIT.Clubs.Data
{
    public interface IClubeRepo
    {
        bool SaveChanges();


        IEnumerable<Club> GetAllClubs();
        Club GetClubById(int id);
        void CreateClub(Club cmd);
        void UpdateClub(Club cmd);
        void DeleteClub(Club cmd);
    }
}