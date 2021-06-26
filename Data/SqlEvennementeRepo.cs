using System;
using System.Collections.Generic;
using System.Linq;
using IIT.Clubs.Models;

namespace IIT.Clubs.Data
{
    public class SqlEvennementeRepo : IEvennementeRepo
    {
        private readonly IITContext _context;

        public SqlEvennementeRepo(IITContext context)
        {
            _context = context;
        }

        public void CreateEvennement(Evennement rsv)
        {
            if (rsv == null)
            {
                throw new ArgumentNullException(nameof(rsv));
            }
            var personne = _context.Personnes.FirstOrDefault(p => p.Id == rsv.IdOrganisateur);
            var club = _context.Clubs.FirstOrDefault(p => p.Id == rsv.IdClub);
            
            rsv.Organisateur = personne;
            rsv.Club = club;
        
            _context.Evennements.Add(rsv);
        }

        public void DeleteEvennement(Evennement cmd)
        {
             if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Evennements.Remove(cmd);
        }

        public IEnumerable<Evennement> GetAllEvennements()
        {
            var evennements = _context.Evennements.ToList();
            evennements.ForEach(r => r.Organisateur = _context.Personnes.FirstOrDefault(p => p.Id == r.IdOrganisateur));
            return evennements;
        }

        public Evennement GetEvennementById(int id)
        {
            var evennement = _context.Evennements.FirstOrDefault(p => p.Id == id);
            if (evennement != null)
            {
                evennement.Organisateur = _context.Personnes.FirstOrDefault(p => p.Id == evennement.IdOrganisateur);
            }
            return evennement;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateEvennement(Evennement cmd)
        {
            //Nothing
        }
    }
}