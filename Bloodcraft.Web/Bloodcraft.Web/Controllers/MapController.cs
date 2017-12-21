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
        private IMapsService maps;
        private UserManager<User> userManager;
        private IKnightsService knights;

        public MapController(IMapsService maps, UserManager<User> userManager, IKnightsService knights)
        {
            this.maps = maps;
            this.userManager = userManager;
            this.knights = knights;
        }

        public async Task<IActionResult> Index()
        {
            var map = new CreatingMapModel();
            map = await this.maps.CreateAsync();
            map.UserId = this.userManager.GetUserId(User);
            return View(map);
        }
    }
}
