using System.Collections.Generic;
using IIT.Clubs.Models;

namespace IIT.Clubs.Data
{
    public interface IReserverRepo
    {
        bool SaveChanges();


        IEnumerable<Reservation> GetAllReservations();
        Reservation GetReservationById(int id);
        void CreateReservation(Reservation cmd);
        void UpdateReservation(Reservation cmd);
        void DeleteReservation(Reservation cmd);
    }
}