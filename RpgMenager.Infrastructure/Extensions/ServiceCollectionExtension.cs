using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RpgMenager.Infrastructure.Persistence;

namespace RpgMenager.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddIntrastructure(this IServiceCollection service, IConfiguration configuration)
        {
            string contetionString = configuration.GetConnectionString("RpgMenager");
            service.AddDbContext<RpgMenagerDbContext>(options => options.UseSqlServer(contetionString));
        }
    }
}
