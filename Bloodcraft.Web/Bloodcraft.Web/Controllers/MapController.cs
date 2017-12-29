namespace Bloodcraft.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Bloodcraft.Services.Users;
    using Bloodcraft.Services.Users.Models;
    using Bloodcraft.Data.Models;
    using Microsoft.AspNetCore.Identity;

    public class MapController : Controller
    {
        private IMapsService mapsService;
        private UserManager<User> userManager;
        private IKnightsService knightsService;

        public MapController(IMapsService maps, UserManager<User> userManager, IKnightsService knights)
        {
            this.mapsService = maps;
            this.userManager = userManager;
            this.knightsService = knights;
        }

        public async Task<IActionResult> Index()
        {
            var map = new CreatingMapModel();
            map = await this.mapsService.CreateAsync();
            map.UserId = this.userManager.GetUserId(User);
            return View(map);
        }
    }
}
