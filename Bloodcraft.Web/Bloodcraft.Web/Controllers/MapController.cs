namespace Bloodcraft.Web.Controllers
{
    using Bloodcraft.Core.WorldMap;
    using Bloodcraft.Web.Models.Map;
    using Microsoft.AspNetCore.Mvc;
    using Bloodcraft.Core.Infrastructure.WorldMap;
    using Bloodcraft.Data;
    using System.Linq;
    using Bloodcraft.Core.Infrastructure;
    using System.Threading.Tasks;

    public class MapController : Controller
    {
        private BloodcraftDbContext db;

        public MapController(BloodcraftDbContext db)
        {
            this.db = db;
        }

        public async Task<IActionResult> Index()
        {
            var map = new CreatingMap
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
                        if (map.Map[i, j] == CoreConstants.CastleSpawnValue && !castles.Any(c=>c.X==i && c.Y == j))
                        {
                            castle.X = i;
                            castle.Y = j;

                           await this.db.SaveChangesAsync();
                        }
                    }
                }
            }
           return View(map);
        }
    }
}
