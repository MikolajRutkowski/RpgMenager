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

                var isEmpty =  _db.ListOfStatistics.Any();
                int x = 10;
                

                if (isEmpty == false)
                {
                    IndexOfStatistic seed = new IndexOfStatistic() { Name = NameOfListOfCharacterTraits, Description = "Bazowa Lista Cech dla Call Cthulhu 7ed."  };
                    seed.Encode();
                    foreach (string s in BaseCharacteristicName)
                    {
                        seed.Add(new Statistic() { Name = s, Value = 1 });
                    }
                    foreach(var s in seed.MainList)
                    {
                        s.Encode();
                    }
                    _db.ListOfStatistics.Add(seed);
                    await _db.SaveChangesAsync();
                }
                if (isEmpty == false)
                {
                    IndexOfStatistic seed = new IndexOfStatistic() { Name = NameOfListOfCharacterSkils, Description = "Bazowa Lista Statystyk dla Call Cthulhu 7ed." };
                    seed.Encode();
                    foreach (string s in SkillNames)
                    {
                        seed.Add(new Statistic() { Name = s, Value = 1 });
                    }
                    foreach (var s in seed.MainList)
                    {
                        s.Encode();
                    }
                    _db.ListOfStatistics.Add(seed);
                    await _db.SaveChangesAsync();
                }
                
            }

        }
    }
}
