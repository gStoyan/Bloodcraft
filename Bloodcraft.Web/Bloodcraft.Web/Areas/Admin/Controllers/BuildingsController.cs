namespace Bloodcraft.Web.Areas.Admin.Controllers
{
    using Bloodcraft.Data.Models;
    using Bloodcraft.Services.Admin;
    using Bloodcraft.Web.Areas.Admin.Models;
    using Bloodcraft.Web.Infrastructure.Filters;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class BuildingsController : AdminBaseController
    {
        private IAdminBuildingsService buildings;
        private UserManager<User> userManager;

        public BuildingsController(UserManager<User> userManager,IAdminBuildingsService buildings)
        {
            this.userManager = userManager;
            this.buildings = buildings;
        }

        public async Task<IActionResult> Index(int page = 1) 
            => View(new AdminBuildingsListingViewModel
        {
                AllBuildings = await this.buildings.AllAsync(),
                TotalBuildings = await this.buildings.TotalBuildingsAsync(),
                CurrentPage = page
        });

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create(AdminBuildingFormModel castle)
        {
            var userId = this.userManager.GetUserId(User);
            var castleId = this.buildings.GetCastleIdAsync(userId);

            await this.buildings.CreateAsync(castleId, castle.Name, castle.ImgUrl, castle.GoldIncome, castle.BloodIncome, castle.GoldCost, castle.BloodCost, castle.BuildTime);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit() => View();

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Edit(AdminBuildingFormModel model, int id)
        {
            var building = await this.buildings.GetById(id);

            await this.buildings.EditAsync(building, model.Name, model.ImgUrl, model.GoldIncome, model.BloodIncome, model.GoldCost, model.BloodCost, model.BuildTime);

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.buildings.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
