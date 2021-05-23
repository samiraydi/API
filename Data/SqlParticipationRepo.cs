/* using System;
using System.Collections.Generic;
using System.Linq;
using IIT.Clubs.API.Data;
using IIT.Clubs.API.Models;
using IIT.Clubs.Models;

namespace IIT.Clubs.Data
{
    public class SqlParticipationRepo : IParticipationRepo
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
         
            var participations = _context.Participations.ToList();
            participations.ForEach(r => r.Evennement = _context.Evennements.FirstOrDefault(p => p.Id == r.IdEvennement));
            participations.ForEach(r => r.Personne = _context.Personnes.FirstOrDefault(p => p.Id == r.IdPersonne));
            return participations;

        }

        public Participation GetParticipationById(int id)
        {
            var participation = _context.Participations.FirstOrDefault(p => p.Id == id);
            if (participation != null)
            {
                participation.Evennement = _context.Evennements.FirstOrDefault(p => p.Id == participation.IdEvennement);
                participation.Personne = _context.Personnes.FirstOrDefault(p => p.Id == participation.IdPersonne);
                if (participation.Evennement.IdOrganisateur != 0)
                {
                    var organisateur = _context.Personnes.FirstOrDefault(p => p.Id == participation.Evennement.IdOrganisateur);
                    participation.Evennement.Organisateur = organisateur;
                }
            }
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
}*/