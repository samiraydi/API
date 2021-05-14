using System;
using System.Collections.Generic;
using System.Linq;
using IIT.Clubs.Models;

namespace IIT.Clubs.Data
{
    public class SqlReserverRepo : IReserverRepo
    {
        private readonly IITContext _context;

        public SqlReserverRepo(IITContext context)
        {
            _context = context;
        }

        public void CreateReservation(Reservation rsv)
        {
            if (rsv == null)
            {
                throw new ArgumentNullException(nameof(rsv));
            }
            var evennement = _context.Evennements.FirstOrDefault(p => p.Id == rsv.IdEvennement);
            var salle = _context.Salles.FirstOrDefault(p => p.Id == rsv.IdSalle);
            rsv.Evennement = evennement;
            rsv.Salle = salle;
            rsv.Statut = "Nouveau";
            _context.Reservations.Add(rsv);
        }

        public void DeleteReservation(Reservation cmd)
        {
             if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Reservations.Remove(cmd);
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
         
            var reservations = _context.Reservations.ToList();
            reservations.ForEach(r => r.Evennement = _context.Evennements.FirstOrDefault(p => p.Id == r.IdEvennement));
            reservations.ForEach(r => r.Salle = _context.Salles.FirstOrDefault(p => p.Id == r.IdSalle));
            return reservations;

        }

        public Reservation GetReservationById(int id)
        {
            var reservation = _context.Reservations.FirstOrDefault(p => p.Id == id);
            if (reservation != null)
            {
                reservation.Evennement = _context.Evennements.FirstOrDefault(p => p.Id == reservation.IdEvennement);
                reservation.Salle = _context.Salles.FirstOrDefault(p => p.Id == reservation.IdSalle);
            }
            return reservation;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateReservation(Reservation cmd)
        {
            //Nothing
        }
    }
}