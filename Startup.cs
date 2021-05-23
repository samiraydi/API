using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IIT.Clubs.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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

           // services.AddDbContext<IITContext>(Options => Options.UseNpgsql(Configuration["Postgres:Client:ConnectionString"]));

            //services.AddDbContext<ReserverContext>(opt => opt.UseSqlServer
            //    (Configuration.GetConnectionString("IITConnection")));

            services.AddControllers().AddNewtonsoftJson(s => {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            services.AddCors();

            // inject dependency "_repository"
            //services.AddScoped<IIITRepo, MockIITRepo>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IReserverRepo, SqlReserverRepo>();
            services.AddScoped<ISalleeRepo, SqlSalleeRepo>();
            services.AddScoped<IEvennementeRepo, SqlEvennementeRepo>();
            services.AddScoped<IPersonneRepo, SqlPersonneRepo>();
            // services.AddScoped<IParticipationRepo, SqlParticipationRepo>();
            services.AddScoped<IMaterialRepo, SqlMaterialRepo>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IIT", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IIT v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x =>x.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
