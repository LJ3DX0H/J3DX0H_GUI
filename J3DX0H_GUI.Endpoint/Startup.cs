using J3DX0H_GUI.Endpoint.Services;
using J3DX0H_GUI.Logic.Interfaces;
using J3DX0H_GUI.Logic.Services;
using J3DX0H_GUI.Models;
using J3DX0H_GUI.Repository.Database;
using J3DX0H_GUI.Repository.Interfaces;
using J3DX0H_GUI.Repository.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace J3DX0H_GUI.Endpoint
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
            services.AddTransient<AlbumDbContext>();
            /*services.AddSingleton<AlbumDbContext>();*/

            services.AddTransient<IRepository<Merchandise>, MerchandiseRepository>();
            services.AddTransient<IRepository<Album>, AlbumRepository>();
            services.AddTransient<IRepository<Band>, BandRepository>();
            services.AddTransient<IRepository<RecordCompany>, RecordCompanyRepository>();


            services.AddTransient<IMerchandiseLogic, MerchandiseLogic>();
            services.AddTransient<IBandLogic, BandLogic>();
            services.AddTransient<IRecordCompanyLogic, RecordCompanyLogic>();
            services.AddTransient<IAlbumLogic, AlbumLogic>();

            services.AddSignalR();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "J3DX0H_GUI.Endpoint", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "J3DX0H_GUI.Endpoint v1"));
            }

            app.UseCors(x => x
                .AllowCredentials()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins("http://localhost:14821"));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}
