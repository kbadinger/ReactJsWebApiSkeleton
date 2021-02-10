using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using AdvWeb.DataAccessLayer;
using AdvWeb.Services;
using AdvWeb.Models;

using Microsoft.AspNetCore.Identity;

namespace AdvWeb
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
            services.AddDbContext<MyDBContext>(options => options.UseMySQL(Configuration.GetConnectionString("advConnection")));


            //            services.AddIdentity<ApplicationUser, IdentityRole>()
            //        .AddEntityFrameworkStores<mysqlContext>().AddDefaultTokenProviders();

            services.AddCors();
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AdvWeb", Version = "v1" });
            });
        }

        private void UpdateDatabase(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();

            using var context = serviceScope.ServiceProvider.GetService<MyDBContext>();

            context.Database.Migrate();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            string[] corssites = { "http://localhost:3000", "http://localhost:3001" };

            app.UseCors(options => options.WithOrigins(corssites).AllowAnyHeader().AllowAnyMethod());


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AdvWeb v1"));
            }

          //  UpdateDatabase(app);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseMiddleware<JwtMiddleware>();

            

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
