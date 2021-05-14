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

        public void CreateEvennement(Evennement cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Evennements.Add(cmd);
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
            return _context.Evennements.ToList();
        }

        public Evennement GetEvennementById(int id)
        {
            return _context.Evennements.FirstOrDefault(p => p.Id == id);
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