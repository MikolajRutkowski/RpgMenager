﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RpgMenager.Domain.Interfaces;
using RpgMenager.Infrastructure.Persistence;
using RpgMenager.Infrastructure.Repositorries;
using RpgMenager.Infrastructure.Seeders;

namespace RpgMenager.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddIntrastructure(this IServiceCollection service, IConfiguration configuration)
        {
            string contetionString = configuration.GetConnectionString("RpgMenager");
            service.AddDbContext<RpgMenagerDbContext>(options => options.UseSqlServer(contetionString));
            service.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<RpgMenagerDbContext>();


            service.AddScoped<SeederOne>();
            service.AddScoped<StatisticSeeder>();
            service.AddScoped<IRpgMenagerRepository, RpgMenagerRepository>();
        }
    }
}
