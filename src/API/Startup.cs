using API.FluentValidation;
using CORE.DTOs;
using CORE.Interfaces;
using CORE.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace API
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
            services.AddControllers();

            services.AddDbContext<dbMVMComunicadoContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("dbMVCcomunicado")));

            //Configurando el servicio de automapper desde cualquier parte de la solucion (dominio)
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddMvc().AddFluentValidation();

            // AddFluentValidation
            services.AddTransient<IValidator<UserSystemDto>, ValidateUserSystem>();

            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUserSystemService, UserSystemService>();
            services.AddTransient<ICompanyStatementService, CompanyStatementService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
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
