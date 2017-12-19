namespace Bloodcraft.Services.Users.Implementations
{
    using Bloodcraft.Data;
    using Bloodcraft.Data.Models;
    using System.Linq;
    using System.Threading.Tasks;

    public class KnightsService : IKnightsService
    {
        private BloodcraftDbContext db;

        public KnightsService(BloodcraftDbContext db)
        {
            this.db = db;
        }

        public async Task  CreateAsync()
        {
            if (db.Knights.Count() != 0)
            {
                return;
            }

            var castles = this.db.Castles.ToList();
            foreach (var castle in castles)
            {
                if (castle.Y <9)
                {
                    var knight = new Knight
                    {
                        X = castle.X,
                        Y = castle.Y + 1,
                        Castle = castle,
                        CastleID = castle.Id
                    };
                    this.db.Knights.Add(knight);

                    await this.db.SaveChangesAsync();
                }
                else if (castle.Y ==9)
                {
                    var knight = new Knight
                    {
                        X = castle.X,
                        Y = castle.Y - 1,
                        Castle = castle,
                        CastleID = castle.Id
                    };
                    this.db.Knights.Add(knight);

                    await this.db.SaveChangesAsync();
                }               
            }
        }
    }
}
