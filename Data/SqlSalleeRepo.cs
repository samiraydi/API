using System;
using System.Collections.Generic;
using System.Linq;
using IIT.Clubs.Models;

namespace IIT.Clubs.Data
{
    public class SqlSalleeRepo : ISalleeRepo
    {
        private readonly IITContext _context;

        public SqlSalleeRepo(IITContext context)
        {
            _context = context;
        }

        public void CreateSalle(Salle cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Salles.Add(cmd);
        }

        public void DeleteSalle(Salle cmd)
        {
             if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Salles.Remove(cmd);
        }

        public IEnumerable<Salle> GetAllSalles()
        {
            return _context.Salles.ToList();
        }

        public Salle GetSalleById(int id)
        {
            return _context.Salles.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateSalle(Salle cmd)
        {
            //Nothing
        }
    }
}