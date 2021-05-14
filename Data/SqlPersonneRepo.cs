using System;
using System.Collections.Generic;
using System.Linq;
using IIT.Clubs.Models;

namespace IIT.Clubs.Data
{
    public class SqlPersonneRepo : IPersonneRepo
    {
        private readonly IITContext _context;

        public SqlPersonneRepo(IITContext context)
        {
            _context = context;
        }

        public void CreatePersonne(Personne cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Personne.Add(cmd);
        }

        public void DeletePersonne(Personne cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Personne.Remove(cmd);
        }

        public IEnumerable<Personne> GetAllPersonne()
        {
            return _context.Personne.ToList();
        }

        public Personne GetPersonneById(int id)
        {
            return _context.Personne.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdatePersonne(Personne cmd)
        {
            //Nothing
        }
    }
}