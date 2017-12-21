namespace Bloodcraft.Web.Controllers
{
    using Bloodcraft.Services.Users;
    using Bloodcraft.Services.Users.Models;
    using Bloodcraft.Web.Models.Castles;
    using Bloodcraft.Web.Models.Minions;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class MinionsController : Controller
    {
        private ICastlesService castles;
        private IMinionsService minions;

        public MinionsController(ICastlesService castles, IMinionsService minions)
        {
            this.castles = castles;
            this.minions = minions;
        }

        public async Task<IActionResult> NotEnoughResources() => View();

        public async Task<IActionResult> Details(int id,string name) =>
            View(
                new MinionsDetailsViewModel
                {
                    AdminCastle = await this.castles.GetAdminCastleAsync(),
                    UserCastle = await this.castles.GetUsersCastleAsync(id),
                    Minion = await this.minions.DetailsAsync(name)
                });
        
        public async Task<IActionResult> Create(int id, string name)
        {
            try
            {
                await this.minions.CreateAsync(id, name);
                ViewData["name"] = name;
                return View();

            }
            catch (System.Exception)
            {
                return RedirectToAction(nameof(NotEnoughResources));
            } 
        }
    }
}
