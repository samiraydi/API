//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using IIT.Clubs.Data;
//using IIT.Clubs.Models;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;

//namespace IIT.Clubs.API.Seeds
//{
//    public static class PrepDB
//    {
//        private static UserManager<Personne> _userManager;
//        private static IITContext _context;
//        public static void PrepPopulation(IApplicationBuilder app)
//        {
//            using (var serviceScope = app.ApplicationServices.CreateScope())
//            {
//                _userManager = serviceScope.ServiceProvider.GetService<UserManager<Personne>>();
//                _context = serviceScope.ServiceProvider.GetService<IITContext>()
//                SeedData();
//            }
//        }

//        private static void SeedData()
//        {
//            System.Console.WriteLine("Migration de la base de données encours ...");
//            _context.Database.Migrate();
//            if (!_context.Clubs.Any())
//            {
//                System.Console.WriteLine("Seeding table Personne");
//                new Club()
//                {
//                    Nom = "Club Robotic",
//                    Description = "Organisation des ateliers pour conception et programmation des système robotiques",
//                    DemaineActivite = "Informatique",
//                    Date = new DateTime(),
//                    Logo = "logo.png",
//                    IdFondateur = 1
//                };
//            }
//            List<Personne> listPersonnes = new List<Personne>();
            
//            Personne p1 = new Personne() { Nom = "Admin", Prenom = "Admin", Email = "admin@iit.com", Password = "Admin-1234", DateNaissance = new DateTime(1995, 08, 05), Occupation = "Directeur", Etablissement = "IIT" });
//            listPersonnes.Add(new Personne() { Nom = "Mohammed Ali", Prenom = "Hammami", Email = "dali@iit.com", Password = "Dali-1234", DateNaissance = new DateTime(1995, 08, 05), Occupation = "Étudiant", Etablissement = "IIT" });
//            listPersonnes.Add(new Personne() { Nom = "Samir", Prenom = "Aydi", Email = "samir@iit.com", Password = "Samir-1234", DateNaissance = new DateTime(1998, 12, 31), Occupation = "Étudiant", Etablissement = "IIT" });
//            //listPersonnes.ForEach(u =>  AddPersonneAsync(u));
//            await AddPersonneAsync(p);
//        }

//        private static async Task AddPersonneAsync(Personne user)
//        {
//            if (!_context.Users.Any(u => u.UserName == user.UserName))
//            {
//                System.Console.WriteLine("Seeding table Personne");

//            }

//            var password = new PasswordHasher<Personne>();
//            var hashed = password.HashPassword(user, user.Password);
//            user.PasswordHash = hashed;

//            UserStore<Personne> userStore = new UserStore<Personne>(_context);
//            var result = userStore.CreateAsync(user);

//            await AssignRoles(user.Email, roles);

//            _context.SaveChangesAsync();


//            if (!_context.Inscriptions.Any())
//            {
//                System.Console.WriteLine("Seeding table Personne");
//                new Inscription() { IdClub = 1, IdMembre = 1 };
//            }
//        }

//        private static Task AssignRoles(string email, object roles)
//        {
//            throw new NotImplementedException();
//        }

//        public static async Task<IdentityResult> AssignRoles(IServiceProvider services, string email, string[] roles)
//        {
           
//            Personne user = await _userManager.FindByEmailAsync(email);
//            var result = await _userManager.AddToRolesAsync(user, roles);

//            return result;
//        }

      
//    }
//}
