using System;
using System.Collections.Generic;
using System.Linq;
using IIT.Clubs.Models;

namespace IIT.Clubs.Data
{
    public class SqlInscriptioneRepo : IInscriptioneRepo
    {
        private readonly IITContext _context;

        public SqlInscriptioneRepo(IITContext context)
        {
            _context = context;
        }

        public void CreateInscription(Inscription cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Inscriptions.Add(cmd);
        }

        public void DeleteInscription(Inscription cmd)
        {
             if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Inscriptions.Remove(cmd);
        }

        public IEnumerable<Inscription> GetAllInscriptions()
        {
            return _context.Inscriptions.ToList();
        }

        public Inscription GetInscriptionById(int id)
        {
            return _context.Inscriptions.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateInscription(Inscription cmd)
        {
            //Nothing
        }
    }
}