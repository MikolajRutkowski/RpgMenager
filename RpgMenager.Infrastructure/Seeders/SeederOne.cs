using RpgMenager.Domain.Entities;
using RpgMenager.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Infrastructure.Seeders
{
    public class SeederOne
    {
        private readonly RpgMenagerDbContext _db;
        public SeederOne(RpgMenagerDbContext db) {  _db = db; }
        public async Task Seed()
        {
            if(await _db.Database.CanConnectAsync())
            {
                if (!_db.Players.Any())
                {
                    var seedPlayer = new Player()
                    {
                        RealFirstName = "Test name",
                        RealLastName = "Test last name"
                        
                    };
                    seedPlayer.CreateName("Testuś");
                    seedPlayer.Encode();
                    _db.Players.Add(seedPlayer);   
                    await _db.SaveChangesAsync();
                }
                if (!_db.PCs.Any())
                {
                    var seed = new PC()
                    {
                        Name = "Tom",
                        Description = "Test"


                    };
                    
                    seed.Encode();
                    _db.PCs.Add(seed);
                    await _db.SaveChangesAsync();
                }
                if (!_db.NPCs.Any())
                {
                    var seed = new NPC()
                    {
                        Name = "Bartek",
                        Description = "Test"


                    };

                    seed.Encode();
                    _db.NPCs.Add(seed);
                    await _db.SaveChangesAsync();
                }
                if (!_db.Items.Any())
                {
                    var seed = new Item()
                    {
                        Name = "Pistolet",
                        Description = "Test"


                    };

                    seed.Encode();
                    _db.Items.Add(seed);
                    await _db.SaveChangesAsync();
                }
                if (!_db.Statistics.Any())
                {
                    var seed = new Statistic()
                    {                        
                        Name = "Siła",

                    };

                    seed.Encode();
                    _db.Statistics.Add(seed);
                    await _db.SaveChangesAsync();
                }

            }
        }
    }
}
