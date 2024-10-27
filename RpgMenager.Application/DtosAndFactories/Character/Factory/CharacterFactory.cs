using AutoMapper;
using MediatR;
using RpgMenager.Application.ApplicationUser;
using RpgMenager.Application.DtosAndFactories.Character.Commands.Create;
using RpgMenager.Domain.Entities;
using RpgMenager.Domain.Entities.Abstract;
using RpgMenager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAndFactories.Character
{
     class CharacterFactory : RpgHandler
    {
        public CharacterFactory(IMapper mapper, IRpgMenagerRepository rpgMenagerRepository, IUserContext userContext) : base(mapper, rpgMenagerRepository, userContext)
        {
        }
        public async Task<Domain.Entities.Abstract.Character> returnCharacterRedyToGoDataBaseAsync(CreateCharacterCommand request)
        {
            Domain.Entities.Abstract.Character returnCharacter;
            switch (request.TypeOfCharacter)
            {
                case "NPC":
                    {
                        NPC character = _mapper.Map<Domain.Entities.NPC>(request);
                        character.Encode();
                        returnCharacter = character;
                        break;
                    }
                case "PC":
                    {
                        PC character = _mapper.Map<Domain.Entities.PC>(request);
                        character.Encode();
                        returnCharacter = character;
                        
                        break;
                    }
                default:
                    throw new Exception("Nieznany typ postaci");
            }
            if (request.AddBasicStats) {
                var allStatistic = await _repository.GetAll<Domain.Entities.IndexOfStatistic>();
                var StatsList = allStatistic.Where(l => l.Name == "Lista Cech")
                    .FirstOrDefault();
                var SkillList = allStatistic
                    .Where(l => l.Name == "Lista Umiejetności").FirstOrDefault();

               returnCharacter = CloneStats(returnCharacter, StatsList);
               returnCharacter = CloneStats(returnCharacter, SkillList);




            }

            

            return returnCharacter;
        }
        Domain.Entities.Abstract.Character CloneStats(Domain.Entities.Abstract.Character character, IndexOfStatistic indexOfStatistic)
        {
            string nameOfNewList = indexOfStatistic.Name + " Postaci " + character.Name;
            character.IndexOfStatistic.Add(new IndexOfStatistic()
            {
                Name = nameOfNewList,
                Description = indexOfStatistic.Description + " Postaci " + character.Name,
                Character = character
            });
            int idOfNewList = character.IndexOfStatistic.FindIndex(x => x.Name == nameOfNewList);
            character.IndexOfStatistic[idOfNewList].Encode(); /// cos to nie dizała zawsze id = 0 
            foreach (var stats in indexOfStatistic.MainList)
            {
                character.IndexOfStatistic[idOfNewList].Add(new Domain.Entities.Statistic(stats));
            }
            return character;
        }

    }
}
