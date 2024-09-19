using Microsoft.Extensions.DependencyInjection;
using RpgMenager.Application.DtosAnd.Player.Queries.GetAllPlayers;
using RpgMenager.Application.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using FluentValidation;
using FluentValidation.AspNetCore;
using RpgMenager.Application.DtosAnd.Player.Commands.Create;


namespace RpgMenager.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllPlayersQuery).Assembly));
            services.AddAutoMapper(typeof(RpgMenagerMappingProfile));

            services.AddValidatorsFromAssemblyContaining<CreatePlayerCommandValidator>()
                .AddFluentValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
