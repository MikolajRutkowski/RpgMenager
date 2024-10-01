using RpgMenager.Domain.Entities;
using RpgMenager.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Infrastructure.Seeders
{
    public class StatisticSeeder
    {
        public readonly List<string> BaseCharacteristicName = new List<string>
        {
           "Siła", // 3k6     
           "Kondycja ", // 3k6
           "Moc ", // 3k6
           "Zręczność ", // 3k6
           "Wygląd ", // 3k6
           "Inteligencja ", //2k6 + 6
           "Wykształcenie ", //2k6 + 6
           "Budowa Ciała",  //2k6 + 6
           "Ruch"
        };
        public readonly List<string> SkillNames = new List<string>
        {
    "Antropologia",
    "Archeologia",
    "Broń palna (Pistolet, Karabin, Strzelba)",
    "Historia",
    "Jazda (samochodem)",
    "Jazda konno",
    "Język (Inny)",
    "Korzystanie z biblioteki",
    "Medycyna",
    "Mitologia Cthulhu",
    "Naprawa elektryczna",
    "Naprawa mechaniczna",
    "Nauka (różne kategorie)",
    "Nawigacja",
    "Obsługa ciężkiego sprzętu",
    "Ocenianie/Wycena",
    "Ocena wiarygodności kredytowej",
    "Okultyzm",
    "Pierwsza pomoc",
    "Przekonywanie",
    "Przebranie/Maskowanie",
    "Przetrwanie",
    "Psychoanaliza",
    "Psychologia",
    "Prawo",
    "Pływanie",
    "Rachunkowość",
    "Rzut",
    "Skok",
    "Skradanie się",
    "Słuchanie",
    "Szybkie rozmawianie",
    "Sztuka/Rzemiosło",
    "Urok/Oczarowanie",
    "Unik",
    "Widzenie ukrytych rzeczy",
    "Wspinaczka",
    "Zastraszenie",
    "Zręczność manualna",
    "Śledzenie",
    "Ślusarstwo",
    "Świat naturalny"
        };

        private string NameOfListOfCharacterTraits = "Lista Cech";
        private string NameOfListOfCharacterSkils = "Lista Umiejetności";
        private readonly RpgMenagerDbContext _db;
        public StatisticSeeder(RpgMenagerDbContext db) {  _db = db; }
        public async Task Seed()
        {
            if (await _db.Database.CanConnectAsync())
            {
                 
                bool IfListOfCharacterTraitsExiste = _db.Statistics.Where(s => s.NameOfTheList == NameOfListOfCharacterTraits).Any();
                if (!IfListOfCharacterTraitsExiste) { 
                    foreach(string traits in BaseCharacteristicName)
                    {
                        var seed = new Statistic()
                        {
                            Name = traits,
                            NameOfTheList = NameOfListOfCharacterTraits,
                            Value = 1,
                            statisticsEnum = Domain.Enums.StatisticsEnum.Character

                        };
                        seed.Encode();
                        _db.Statistics.Add(seed);
                        await _db.SaveChangesAsync();
                    }
                }
                bool IfListOfSkilstsExiste = _db.Statistics.Where(s => s.NameOfTheList == NameOfListOfCharacterSkils).Any();
                if (!IfListOfSkilstsExiste) {
                    foreach (string skil in SkillNames)
                    {
                        var seed = new Statistic()
                        {
                            Name = skil,
                            NameOfTheList = NameOfListOfCharacterSkils,
                            Value = 0,
                            statisticsEnum = Domain.Enums.StatisticsEnum.Skill

                        };
                        seed.Encode();
                        _db.Statistics.Add(seed);
                        await _db.SaveChangesAsync();
                    }
                }
            }
        }
    }
}
