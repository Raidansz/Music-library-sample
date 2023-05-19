
using ATWSMF_SGUI_2022_23_2.Data;
using ATWSMF_SGUI_2022_23_2.Logic.Classes;
using ATWSMF_SGUI_2022_23_2.Logic.Interfaces;
using ATWSMF_SGUI_2022_23_2.Repository.Classes;
using ATWSMF_SGUI_2022_23_2.Repository.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATWSMF_SGUI_2022_23_2.Endpoint
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // TODO: show Add dependencies in the order they are needed!
            services.AddTransient<DbContext, SongContext>();
            services.AddTransient<IArtistRepository, ArtistRepository>();
            services.AddTransient<IAlbumRepository, AlbumRepository>();
            services.AddTransient<ISongRepository, SongRepository>();
            services.AddTransient<IArtistLogic, ArtistLogic>();
            services.AddTransient<IAlbumLogic, AlbumLogic>();
            services.AddTransient<ISongLogic, SongLogic>();


            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .WithHeaders("Content-Type");
                });
            });

            // TODO: show Add controllers
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(builder =>
            {
                builder.WithOrigins("http://localhost:1337");
            });
            app.UseCors();
            app.UseEndpoints((config) =>
            {
                // TODO: show register the controllers
                config.MapControllers();
            });
        }
    }
}
