﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;

namespace WebApplication1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Ajouter le contexte
            services.AddDbContext<MyContext>(options =>
            {
                //options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogDataBase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                options.UseSqlServer(@"Server=tcp:blogdatabaseserver.database.windows.net,1433;Initial Catalog=BlogDatabase;Persist Security Info=False;User ID=sebastien;Password=Passw0rdPassw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            });

            //Ajouter l'authentification avec Identity
            services.AddIdentity<Microsoft.AspNetCore.Identity.IdentityUser, Microsoft.AspNetCore.Identity.IdentityRole>();

            //Ajouter la prise en charge de MVC
            services.AddMvc();

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});


            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });


            //Configurer MVC
            app.UseMvc(route => 
            {
                route.MapRoute("default", "{controller=home}/{action=index}/{id?}");
            });




        }
    }
}
