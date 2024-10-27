using Microsoft.Extensions.DependencyInjection;
using RpgMenager.Application.DtosAndFactories.Player.Queries.GetAllPlayers;
using RpgMenager.Application.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using FluentValidation;
using FluentValidation.AspNetCore;
using RpgMenager.Application.DtosAndFactories.Player.Commands.Create;
using RpgMenager.Application.ApplicationUser;
using AutoMapper;


namespace RpgMenager.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserContext, UserContext>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllPlayersQuery).Assembly));
            
            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                var scope = provider.CreateScope();
                var userContext = scope.ServiceProvider.GetRequiredService<IUserContext>();
                cfg.AddProfile(new RpgMenagerMappingProfile(userContext));
            }).CreateMapper()
            );


            services.AddValidatorsFromAssemblyContaining<CreatePlayerCommandValidator>()
                    .AddFluentValidation()
                    .AddFluentValidationClientsideAdapters();
        }
    }
}
