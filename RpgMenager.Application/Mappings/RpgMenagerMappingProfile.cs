using AutoMapper;
using RpgMenager.Application.DtosAnd.Character;
using RpgMenager.Application.DtosAnd.Character.Commands.Edit;
using RpgMenager.Application.DtosAnd.Player;
using RpgMenager.Application.DtosAnd.Player.Commands.Edit;
using RpgMenager.Application.DtosAnd.Statistic;
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
            //   .ForMember(dest => dest.Statistics, opt => opt.MapFrom(src => src.ListOfStatistics));  // Ignorujemy pole Type podczas mapowania

            CreateMap<NPC, CharacterDto>().ForMember(dest => dest.TypeOfCharacter, opt => opt.Ignore());
            //.ForMember(dest => dest.Statistics, opt => opt.MapFrom(src => src.ListOfStatistics))

            CreateMap<CharacterDto, NPC>();

            CreateMap<CharacterDto, PC>();
            CreateMap<Statistic, StatisticDto>();
            CreateMap<StatisticDto, Statistic>();

            CreateMap<CharacterDto, EditCharacterCommand>();
        }
    }
}
