using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IIT.Clubs.Configuration;
using IIT.Clubs.Data;
using IIT.Clubs.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;

namespace IIT.Clubs
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
             services.AddDbContext<IITContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("IITConnection")));

            //services.AddDbContext<IITContext>(Options => Options.UseNpgsql(Configuration["Postgres:Client:ConnectionString"]));

            
            services.AddControllers().AddNewtonsoftJson(s => {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
            services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));

            // within this section we are configuring the authentication and setting the default scheme
            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwt => {
                var key = Encoding.ASCII.GetBytes(Configuration["JwtConfig:Secret"]);

                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true, // this will validate the 3rd part of the jwt token using the secret that we added in the appsettings and verify we have generated the jwt token
                    IssuerSigningKey = new SymmetricSecurityKey(key), // Add the secret key to our Jwt encryption
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = false,
                    ValidateLifetime = true
                };
            });
            // services.AddIdentity<Personne, IdentityRole<int>>()ttt
            services.AddDefaultIdentity<Personne>(options => options.SignIn.RequireConfirmedAccount = true)
               .AddRoles<IdentityRole<int>>()
         
               .AddEntityFrameworkStores<IITContext>();
            // inject dependency "_repository"
            //services.AddScoped<IIITRepo, MockIITRepo>();  
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IReserverRepo, SqlReserverRepo>();
            services.AddScoped<ISalleeRepo, SqlSalleeRepo>();
            services.AddScoped<IEvennementeRepo, SqlEvennementeRepo>();

            services.AddScoped<IPersonneRepo, SqlPersonneRepo>();
            services.AddScoped<IParticipationeRepo, SqlParticipationRepo>();
            services.AddScoped<IMaterialRepo, SqlMaterialRepo>();

            services.AddScoped<IClubeRepo, SqlClubeRepo>();
            services.AddScoped<IInscriptioneRepo, SqlInscriptioneRepo>();
            

            services.AddSwaggerGen(c =>
            {
                //c.SwaggerDoc("v1", new OpenApiInfo { Title = "", Version = "v1" });
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "IIT Services ClubAPI",
                    Version = "v1",
                    Description = "API pour servir les étudiants et les agents administratifs à gérer leurs clubs",
                });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder => { builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin(); });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IIT API Clubs v1"));
            //}

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x =>x.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
