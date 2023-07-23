using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuestaEnneagram.DbLayer;
using QuestaEnneagram.ServiceLayer.AutoMapper;
using QuestaEnneagram.ServiceLayer.EF.Interface;
using QuestaEnneagram.ServiceLayer.EF.Service;
using QuestaEnneagram.ServiceLayer.Interface;
using QuestaEnneagram.ServiceLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestaEnneagram.ServiceLayer.ServiceExtension
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
        {
           
            services.AddDbContext<QuestaDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddAutoMapper(typeof(AutoMappingProfile).Assembly);
            services.AddScoped<IUnitOfWork, UnitofWorkRepo>();
            services.AddScoped<IMaster, Mastersvc>();
            services.AddScoped<ICandidate, Candidatesvc>();
            services.AddScoped<IMail, Mailsvc>();
            return services;
        }
    }
}
