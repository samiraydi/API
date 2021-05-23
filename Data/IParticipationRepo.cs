/* using IIT.Clubs.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIT.Clubs.API.Data
{
    public interface IParticipationRepo
    {
        bool SaveChanges();

        IEnumerable<Participation> GetAllParticipations();
        Participation GetParticipationById(int id);
        void CreateParticipation(Participation cmd);
        void UpdateParticipation(Participation cmd);
        void DeleteParticipation(Participation cmd);
    }
}
*/