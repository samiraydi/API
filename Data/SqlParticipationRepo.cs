using System;
using System.Collections.Generic;
using System.Linq;
using IIT.Clubs.Models;

namespace IIT.Clubs.Data
{
    public class SqlParticipationRepo : IParticipationeRepo
    {
        private readonly IITContext _context;

        public SqlParticipationRepo(IITContext context)
        {
            _context = context;
        }

        public void CreateParticipation(Participation rsv)
        {
            if (rsv == null)
            {
                throw new ArgumentNullException(nameof(rsv));
            }

            _context.Participations.Add(rsv);
        }

        public void DeleteParticipation(Participation cmd)
        {
             if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Participations.Remove(cmd);
        }

        public IEnumerable<Participation> GetAllParticipations()
        {
            List<Participation> participations = new();
            participations = _context.Participations.ToList();
            participations.ForEach(r => r.Evennement = _context.Evennements.FirstOrDefault(p => p.Id == r.IdEvennement));
            participations.ForEach(r => r.Participant = _context.Personnes.FirstOrDefault(p => p.Id == r.IdParticipant));
            return participations;

        }

        public Participation GetParticipationById(int id)
        {
            Participation participation = new Participation(); 
            participation = _context.Participations.FirstOrDefault(p => p.Id == id);
            participation.Evennement = _context.Evennements.FirstOrDefault(p => p.Id == participation.IdEvennement);
            participation.Participant = _context.Personnes.FirstOrDefault(p => p.Id == participation.IdParticipant);


            return participation;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateParticipation(Participation cmd)
        {
            //Nothing
        }
    }
}