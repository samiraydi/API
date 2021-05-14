using System.Collections.Generic;
using IIT.Clubs.Models;

namespace IIT.Clubs.Data
{
    public interface ISalleeRepo
    {
        bool SaveChanges();


        IEnumerable<Salle> GetAllSalles();
        Salle GetSalleById(int id);
        void CreateSalle(Salle cmd);
        void UpdateSalle(Salle cmd);
        void DeleteSalle(Salle cmd);
    }
}