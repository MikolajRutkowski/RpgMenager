using AutoMapper;
using RpgMenager.Application.DtosAndFactories.Character;
using RpgMenager.Application.DtosAndFactories.Character.Commands.Edit;
using RpgMenager.Application.DtosAndFactories.Index;
using RpgMenager.Application.DtosAndFactories.Player;
using RpgMenager.Application.DtosAndFactories.Player.Commands.Edit;
using RpgMenager.Application.DtosAndFactories.Statistic;
using RpgMenager.Domain.Entities;
using RpgMenager.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.Mappings
{
    public class RpgMenagerMappingProfile : Profile
    {
        public RpgMenagerMappingProfile() {
            CreateMap<Player, PlayerDto>();
            CreateMap<PlayerDto, Player>()
                .ForMember(dest => dest.PlayerCharacters, opt => opt.MapFrom(src => src.PlayerCharacters)); ;
            CreateMap<PlayerDto,EditPlayerCommand>();
            CreateMap<Character, CharacterDto>()
                .ForMember(dest => dest.TypeOfCharacter, opt => opt.MapFrom(src =>
                src is PC ? "PC" : src is NPC ? "NPC" : "Unknown")); 
            CreateMap<CharacterDto, Character>();
            CreateMap<PC, CharacterDto>().ForMember(dest => dest.TypeOfCharacter, opt => opt.Ignore());
            //   .ForMember(dest => dest.IndexOfStatistic, opt => opt.MapFrom(src => src.HasListOfList));  // Ignorujemy pole Type podczas mapowania

            CreateMap<NPC, CharacterDto>().ForMember(dest => dest.TypeOfCharacter, opt => opt.Ignore());
            //.ForMember(dest => dest.IndexOfStatistic, opt => opt.MapFrom(src => src.HasListOfList))

            CreateMap<CharacterDto, NPC>();

            CreateMap<CharacterDto, PC>();
            CreateMap<Statistic, StatisticDto>();
            CreateMap<StatisticDto, Statistic>();

            CreateMap<CharacterDto, EditCharacterCommand>();

            CreateMap<IndexOfStatistic,StatisticIndexDto>();
            CreateMap<StatisticIndexDto, IndexOfStatistic>();


        }
    }
}
