namespace Bloodcraft.Web.Controllers
{
    using Bloodcraft.Services.Users;
    using Bloodcraft.Web.Models.Buildings;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    public class BuildingsController : Controller
    {
        private ICastlesService castlesService;
        private IBuildingsService buildingsService;

        public BuildingsController(ICastlesService castlesService, IBuildingsService buildingsService)
        {
            this.castlesService = castlesService;
            this.buildingsService = buildingsService;
        }
        public async Task<IActionResult> NotEnoughResources() => View();

        public async Task<IActionResult> Details(int id, string name) =>
            View(
                new BuildingsDetailsViewModel
                {
                    AdminCastle = await this.castlesService.GetAdminCastleAsync(),
                    UserCastle = await this.castlesService.GetUsersCastleAsync(id),
                    Building = await this.buildingsService.DetailsAsync(name)
                });

        public async Task<IActionResult> Create(int id, string name)
        {
            try
            {
                await this.buildingsService.CreateAsync(id, name);
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
