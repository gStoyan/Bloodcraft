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
        private UserManager<User> userManager;
        private ICastlesService castlesService;
        private IMapsService mapsService;
        private IKnightsService knightsService;

        public MapController(IMapsService mapsService,
            UserManager<User> userManager,
            IKnightsService knightsService,
            ICastlesService castlesService)
        {
            this.mapsService = mapsService;
            this.userManager = userManager;
            this.knightsService = knightsService;
            this.castlesService = castlesService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = this.userManager.GetUserId(User);

            var map = new CreatingMapModel();
            map = await this.mapsService.CreateAsync();
            map.UserId = userId;
            map.UserCastles = await this.castlesService.GetAllUsersCastlesAsync(userId);
            return View(map);
        }
    }
}
