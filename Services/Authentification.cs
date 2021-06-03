//using BC = BCrypt.Net.BCrypt;
//using System.Linq;
//using IIT.Clubs.Data;
//using IIT.Clubs.Services;
//using IIT.Clubs.Dtos;
//using Microsoft.Extensions.Configuration;
//using System.IdentityModel.Tokens;
//using System.Configuration;
//using System.Text;
//using System;

//namespace IIt.Clubs.Services
//{

//    public class Authentification : IAuthentification
//    {
//        private readonly IITContext _context;

//        public Authentification(IITContext context)
//        {
//            _context = context;
//        }

   

//        public bool Authentifier(AuthentificateRequest request)
//        {
//            throw new NotImplementedException();
//            //// get account from database
//            //var account = _context.Inscriptions.SingleOrDefault(x => x.Email == request.Login);
//            ////SymmetricSecurityKey(Encoding.ASCII.GetBytes(ConfigurationManager.AppSettings["secret"];
//            //// check account found and verify password
//            //if (account == null || !BC.Verify(request.Password, account.PasswordHash))
//            //{
//            //    // authentication failed
//            //    return false;
//            //}
//            //else
//            //{
//            //    // authentication successful
//            //    return true;
//            //}
//        }
//    }
//}