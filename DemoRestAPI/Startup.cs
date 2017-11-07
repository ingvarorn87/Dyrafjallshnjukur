﻿using BLL;
using BLL.BusinessObjects;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CustomerRestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

		//public Startup(IHostingEnvironment env)
		//{
		//	var builder = new ConfigurationBuilder()
		//		.SetBasePath(env.ContentRootPath)
		//		.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
		//		.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
		//		.AddEnvironmentVariables();
		//	Configuration = builder.Build();
		//}

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

			services.AddCors(o => o.AddPolicy("MyPolicy", builder => {
				builder.WithOrigins("http://localhost:4200")
					   .AllowAnyMethod()
					   .AllowAnyHeader();
			}));

            //services.AddSingleton(Configuration);
            
        
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                var facade = new BLLFacade();

                /*var actionGenre = facade.GenreService.Create(
                        new GenreBO()
                        {
                            Name = "Action"
                        });

                facade.VideoService.Create(
                      new VideoBO()
                      {
                          VideoName = "THIS GENRE TEST",
                          GenreId = actionGenre.Id

                      });*/

                //facade.VideoService.Create(
                //    new VideoBO()
                //    {
                //        VideoName = "Iron Man"

                //    });
                //facade.VideoService.Create(
                //    new VideoBO()
                //    {
                //        VideoName = "Thor"

                //    });



            }

            app.UseMvc();
        }
    
    }
}

