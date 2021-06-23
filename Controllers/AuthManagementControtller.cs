using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IIT.Clubs.Configuration;
using IIT.Clubs.Data;
using IIT.Clubs.Dtos;
using IIT.Clubs.Dtos.Request;
using IIT.Clubs.Dtos.Response;
using IIT.Clubs.Models;
using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;


namespace IIT.Clubs.Controllers
{
    [Route("api/Authentification")] // api/authmanagement
    [ApiController]
    public class AuthManagementController : ControllerBase
    {
        private readonly UserManager<Personne> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly JwtConfig _jwtConfig;
       
        
   

        public AuthManagementController(UserManager<Personne> userManager, RoleManager<IdentityRole<int>> roleManager, IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            _userManager = userManager;
            _jwtConfig = optionsMonitor.CurrentValue;
            _roleManager = roleManager;
            

        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequestDto model)
        {
          
                // check i the user with the same email exist
                var existingUser = await _userManager.FindByEmailAsync(model.Email);

                if (existingUser != null)
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Result = false,
                        Errors = new List<string>(){
                                            "Email already exist"
                                        }
                    });
                }
            var newUser = new Personne() {
                Nom = model.Nom,
                Prenom = model.Prenom,
                DateNaissance = model.DateNaissance,
                Occupation= model.Occupation,
                Etablissement= model.Etablissement,
                Email= model.Email,
                UserName= model.Email,
                };
               
            
                var isCreated = await _userManager.CreateAsync(newUser, model.Password);
                var result = await _userManager.CreateAsync(newUser, model.Password);
                if (!result.Succeeded)
                    return StatusCode(StatusCodes.Status500InternalServerError, new RegistrationResponse { Status = $"{result.Errors.ToList()[0].Code}", Message = $"{result.Errors.ToList()[0].Description}" });

                await AddMembreRoleAsync(newUser);

                var user = await _userManager.FindByNameAsync(model.Email);
                var Inscription = new Inscription() {
                    IdMembre = user.Id,
                    IdClub = model.IdClub
                };
                return Ok(new RegistrationResponse { Status = "Success", Message = "User Created Successfully" });
          

        }


        [HttpPost]
        [Route("RegisterAdmin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] UserRegistrationRequestDto model)
        {
            var userExist = await _userManager.FindByNameAsync(model.Email);
            if (userExist != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new RegistrationResponse { Status = "Error", Message = " User Already Exist" });

            Personne newUser = new Personne()
            {
                Nom = model.Nom,
                Prenom = model.Prenom,
                DateNaissance = model.DateNaissance,
                Occupation = model.Occupation,
                Etablissement = model.Etablissement,
                Email = model.Email,
                UserName = model.Email,
            };

            var result = await _userManager.CreateAsync(newUser, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new RegistrationResponse { Status = $"{result.Errors.ToList()[0].Code}", Message = $"{result.Errors.ToList()[0].Description}" });

            await AddAdminRoleAsync(newUser);

            return Ok(new RegistrationResponse { Status = "Success", Message = "User Created Successfully" });
        }
       
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDto model)
        {
            var user = await _userManager.FindByNameAsync(model.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                var jwtToken = GenerateJwtToken(user);

                return Ok(new RegistrationResponse()
                {
                    Result = true,
                    Token = jwtToken
                });

    
            }
            return Unauthorized();
        }
        private async Task AddAdminRoleAsync(Personne user)
        {
            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole<int>(UserRoles.Admin));

            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRolesAsync(user, new List<string>() { UserRoles.Admin });
            }

        }
        private async Task AddMembreRoleAsync(Personne user)
        {

            if (!await _roleManager.RoleExistsAsync(UserRoles.Membre))
                await _roleManager.CreateAsync(new IdentityRole<int>(UserRoles.Membre));

            if (await _roleManager.RoleExistsAsync(UserRoles.Membre))
            {
                await _userManager.AddToRolesAsync(user, new List<string>() { UserRoles.Membre });
            }

        }
        private string GenerateJwtToken(IdentityUser<int> user)
        {
            // Now its ime to define the jwt token which will be responsible of creating our tokens
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            // We get our secret from the appsettings
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            // we define our token descriptor
            // We need to utilise claims which are properties in our token which gives information about the token
            // which belong to the specific user who it belongs to
            // so it could contain their id, name, email the good part is that these information
            // are generated by our server and identity framework which is valid and trusted
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
             //  new Claim("Id", user.Id),
               new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                // the JTI is used for our refresh token which we will be convering in the next video
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }),
                // the life span of the token needs to be shorter and utilise refresh token to keep the user signedin
                // but since this is a demo app we can extend it to fit our current need
                Expires = DateTime.UtcNow.AddHours(6),
                // here we are adding the encryption alogorithim information which will be used to decrypt our token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);

            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}
