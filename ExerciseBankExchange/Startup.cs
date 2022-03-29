using ExerciseBankExchange.Entities.DbContextss;
using ExerciseBankExchange.Services;
using ExerciseBankExchange.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using System;

namespace ExerciseBankExchange
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
            services.AddHttpClient("NbpRate170322", c =>
            {
                c.BaseAddress = new Uri("https://api.nbp.pl/api/exchangerates/rates/a/eur/2022-03-17/?format=json");
            });
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<INbpService, NbpService>();
            services.AddScoped<IExchanger, Exchanger>();
            services.AddDbContext<AccountContext>(opts => opts.UseSqlServer(Configuration.GetConnectionString("MyConnectionString")));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
