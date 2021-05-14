using System.Collections.Generic;
using IIT.Clubs.Models;

namespace IIT.Clubs.Data
{
    public interface IEvennementeRepo
    {
        bool SaveChanges();


        IEnumerable<Evennement> GetAllEvennements();
        Evennement GetEvennementById(int id);
        void CreateEvennement(Evennement cmd);
        void UpdateEvennement(Evennement cmd);
        void DeleteEvennement(Evennement cmd);
    }
}