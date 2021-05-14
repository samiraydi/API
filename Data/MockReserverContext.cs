using System.Collections.Generic;
using IIT.Clubs.Models;

namespace IIT.Clubs.Data
{
    public class MockReserverContext : IReserverRepo
    {
        public void CreateReservation(Reservation cmd)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteReservation(Reservation cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
            throw new System.NotImplementedException();
        }

        public Reservation GetReservationById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateReservation(Reservation cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}