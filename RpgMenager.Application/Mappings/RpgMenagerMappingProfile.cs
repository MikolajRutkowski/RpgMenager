using AutoMapper;
using RpgMenager.Application.DtosAnd.Character;
using RpgMenager.Application.DtosAnd.Player;
using RpgMenager.Application.DtosAnd.Player.Commands.Edit;
using RpgMenager.Domain.Entities;
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
            CreateMap<PC, CharacterDto>();
            CreateMap<NPC, CharacterDto>();
            CreateMap<CharacterDto, NPC>();
            CreateMap<CharacterDto, PC>();
        }
    }
}
