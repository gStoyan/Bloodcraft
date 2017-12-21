namespace Bloodcraft.Web.Controllers
{
    using Bloodcraft.Services.Users;
    using Bloodcraft.Web.Models.Buildings;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    public class BuildingsController : Controller
    {
        private ICastlesService castles;
        private IBuildingsService buildings;

        public BuildingsController(ICastlesService castles, IBuildingsService buildings)
        {
            this.castles = castles;
            this.buildings = buildings;
        }
        public async Task<IActionResult> NotEnoughResources() => View();

        public async Task<IActionResult> Details(int id, string name) =>
            View(
                new BuildingsDetailsViewModel
                {
                    AdminCastle = await this.castles.GetAdminCastleAsync(),
                    UserCastle = await this.castles.GetUsersCastleAsync(id),
                    Building = await this.buildings.DetailsAsync(name)
                });

        public async Task<IActionResult> Create(int id, string name)
        {
            try
            {
                await this.buildings.CreateAsync(id, name);
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
