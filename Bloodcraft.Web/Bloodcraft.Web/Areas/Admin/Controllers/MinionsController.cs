namespace Bloodcraft.Web.Areas.Admin.Controllers
{
    using Bloodcraft.Services.Admin;
    using Bloodcraft.Web.Areas.Admin.Models;
    using Bloodcraft.Web.Infrastructure.Filters;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class MinionsController : AdminBaseController
    {
        private IAdminMinionsService minionsService;

        public MinionsController(IAdminMinionsService minions)
        {
            this.minionsService = minions;
        }

        public async Task<IActionResult> Index(int page = 1)
      =>
        View(new AdminMinionsListingViewModel
        {
            AllMinions = await this.minionsService.AllAsync(page),
            TotalMinions = await this.minionsService.TotalMinionsAsync(),
            CurrentPage = page,
        });

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create(AdminMinionFormModel minion)
        {
            await this.minionsService.CreateAsync(minion.Name,
                minion.ImgUrl,
                minion.GoldCost,
                minion.BloodCost,
                minion.AttackPoints,
                minion.DefencePoints,
                minion.BloodPoints);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit() => View();

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Edit(AdminMinionFormModel minionModel,int id)
        {
            var minion = await this.minionsService.GetById(id);
            await this.minionsService.EditAsync(
                minion,
                minionModel.Name,
                minionModel.ImgUrl,
                minionModel.GoldCost,
                minionModel.BloodCost,
                minionModel.AttackPoints,
                minionModel.DefencePoints,
                minionModel.BloodPoints);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.minionsService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
