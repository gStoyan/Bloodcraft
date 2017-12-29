namespace Bloodcraft.Services.Users.Implementations
{
    using System.Threading.Tasks;
    using Bloodcraft.Services.Users.Models;
    using Bloodcraft.Core.WorldMap;
    using Bloodcraft.Data;
    using System.Linq;
    using Bloodcraft.Core.Infrastructure;
    using Bloodcraft.Data.Models;

    public class MapsService : IMapsService
    {
        private BloodcraftDbContext db;
        private ICastlesService castles;

        public MapsService(BloodcraftDbContext db, ICastlesService castles)
        {
            this.db = db;
            this.castles = castles;
        }

        public async Task<CreatingMapModel> CreateAsync()
        {
            var map = new CreatingMapModel
            {
                Map = CreateMap.Create(this.db.Castles.Count())
            };

            var castles = this.db.Castles.ToList();

            foreach (var castle in castles)
            {
                for (int i = 0; i < map.Map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.Map.GetLength(1); j++)
                    {
                        if (map.Map[i, j] == CoreConstants.CastleSpawnValue && !castles.Any(c => c.X == i && c.Y == j))
                        {  
                            castle.X = i;
                            castle.Y = j;

                            await this.db.SaveChangesAsync();
                        }
                    }
                }
            }
            map.Castles = await this.castles.GetAllCastlesAsync();

            return map;
        }
    }
}
