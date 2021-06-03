using System.Collections.Generic;
using IIT.Clubs.Models;

namespace IIT.Clubs.Data
{
    public interface IParticipationeRepo
    {
        bool SaveChanges();


        IEnumerable<Participation> GetAllParticipations();
        Participation GetParticipationById(int id);
        void CreateParticipation(Participation cmd);
        void UpdateParticipation(Participation cmd);
        void DeleteParticipation(Participation cmd);
    }
}