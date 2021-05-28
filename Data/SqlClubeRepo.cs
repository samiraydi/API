using System;
using System.Collections.Generic;
using System.Linq;
using IIT.Clubs.Models;

namespace IIT.Clubs.Data
{
    public class SqlClubeRepo : IClubeRepo
    {
        private readonly IITContext _context;

        public SqlClubeRepo(IITContext context)
        {
            _context = context;
        }

        public void CreateClub(Club cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Clubs.Add(cmd);
        }

        public void DeleteClub(Club cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Clubs.Remove(cmd);
        }

        public IEnumerable<Club> GetAllClubs()
        {
            var clubs =_context.Clubs.ToList();
            clubs.ForEach(c => c.Fondateur = _context.Personnes.FirstOrDefault(p => p.Id == c.IdFondateur));
            return clubs;
        }

        public Club GetClubById(int id)
        {
            var club = _context.Clubs.FirstOrDefault(p => p.Id == id);
            if (club != null)
                club.Fondateur = _context.Personnes.FirstOrDefault(p => p.Id == club.IdFondateur);
            return club;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateClub(Club cmd)
        {
            //Nothing
        }
    }
}