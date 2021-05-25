using System.Collections.Generic;
using IIT.Clubs.Models;

namespace IIT.Clubs.Data
{
    public interface IInscriptioneRepo
    {
        bool SaveChanges();


        IEnumerable<Inscription> GetAllInscriptions();
        Inscription GetInscriptionById(int id);
        void CreateInscription(Inscription cmd);
        void UpdateInscription(Inscription cmd);
        void DeleteInscription(Inscription cmd);
    }
}