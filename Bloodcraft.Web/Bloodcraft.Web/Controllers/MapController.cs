namespace Bloodcraft.Web.Controllers
{
    using Bloodcraft.Core.WorldMap;
    using Microsoft.AspNetCore.Mvc;
    using Bloodcraft.Data;
    using System.Linq;
    using Bloodcraft.Core.Infrastructure;
    using System.Threading.Tasks;
    using Bloodcraft.Services.Users;
    using Bloodcraft.Services.Users.Models;

    public class MapController : Controller
    {
        private IMapsService maps;
        private BloodcraftDbContext db;
        private ICastlesService castles;

        public MapController(BloodcraftDbContext db, ICastlesService castles,IMapsService maps)
        {
            this.db = db;
            this.castles = castles;
            this.maps = maps;
        }

        public async Task<IActionResult> Index()
        {
            var map = new CreatingMapModel();
            map = await this.maps.CreateAsync();
            return View(map);
        }
    }
}
