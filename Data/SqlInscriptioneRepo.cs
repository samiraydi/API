using BC = BCrypt.Net.BCrypt;
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

        public void CreateInscription(Inscription account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }


            // hash password
            account.Password = HashPassword(account.Password);

            // save account
            _context.Inscriptions.Add(account);
            _context.SaveChanges();
        }

        public bool Authentifier(Inscription model)
        {
            // get account from database
            var account = _context.Inscriptions.SingleOrDefault(x => x.Login == model.Login);

            // check account found and verify password
            if (account == null || !BC.Verify(model.Password, account.PasswordHash))
            {
                // authentication failed
                return false;
            }
            else
            {
                // authentication successful
                return true;
            }
        }

        private string HashPassword(string password)
        {
            return BC.HashPassword(password);
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
            List<Inscription> inscrips = new List<Inscription>();
            inscrips = _context.Inscriptions.ToList();
            inscrips.ForEach(i => i.Club = _context.Clubs.FirstOrDefault(c => c.Id == i.IdClub));
            inscrips.ForEach(i => i.Membre = _context.Personnes.FirstOrDefault(m => m.Id == i.IdMembre));
            return inscrips;
        }

        public Inscription GetInscriptionById(int id)
        {
            Inscription inscrip = new Inscription(); 
            inscrip = _context.Inscriptions.FirstOrDefault(i => i.Id == id);
            inscrip.Club = _context.Clubs.FirstOrDefault(c => c.Id == inscrip.IdClub);
            inscrip.Membre = _context.Personnes.FirstOrDefault(p => p.Id == inscrip.IdMembre);
            return inscrip;
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